using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StateManager : MonoBehaviour
{
	public const int MAXIMUM_SUSPICION_LEVEL = 50;
	public const string EVIDENCE_KNIFE = "knife";
	public const string EVIDENCE_PHONE = "phone";
	public const string EVIDENCE_HANDPRINT = "handprint";
	public const string EVIDENCE_WALLET = "wallet";
	public const string EVIDENCE_FOOTPRINT = "footprint";
	public const string EVIDENCE_NECKLACE = "necklace";

	public const int BALL_THROWN = 2;
	public const int BALL_THROWING = 1;
	public const int BALL_AVAILABLE = 0;

	public static int[] ballStates = { BALL_AVAILABLE, BALL_AVAILABLE };
	public static string[] ballNames = { "Ball1", "Ball2" };

	private static Dictionary<string, string> detected = new Dictionary<string, string> ();

	public GameObject[] targets = new GameObject[]{};

	public static string[] EVIDENCES = {
		EVIDENCE_KNIFE,
		EVIDENCE_PHONE,
		EVIDENCE_HANDPRINT,
		EVIDENCE_WALLET,
		EVIDENCE_FOOTPRINT,
		EVIDENCE_NECKLACE
	};

	public enum GameState
	{
		Briefing,
		Pda,
		Dialog,
		Playing,
		Debriefing
	}

	public int suspicionLevel = 0;
	public int detectionCount = 0;
	public int evidenceCount = 0;
	float timeScale;
	bool paused = false;
	HashSet<string> flags = new HashSet<string> ();

	public GameObject briefingPanel;
	public GameObject debriefingPanel;
	public GameObject pdaPanel;
	public GameObject journalPanel;
	public GameObject dialogPanel;
	public GameObject hudPanel;
	public GameObject gameOverPanel;
	public GameState currentState = GameState.Playing;

	public Image crosshairs;

	public static StateManager instance;

	void Awake ()
	{
		StateManager.instance = this;
		ChangeGameState (GameState.Playing);
		ResetGame ();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		CursorManager.instance.CrosshairsCursor ();

		InvokeRepeating ("UpdateSuspicion", 0f, 1.0f);
	}

	void Update ()
	{
		switch (StateManager.instance.currentState) {
		case StateManager.GameState.Playing:
			if (Input.GetKeyDown (KeyCode.J) || Input.GetButtonDown ("Cancel")) {
				ChangeGameState (GameState.Pda);
			}
			
			if (Input.GetButtonDown ("Help")) {
				GetComponent<HelpDialog> ().ShowHelp ();
			}
			
			if (Input.GetKeyDown (KeyCode.P)) {
				PrintFlags ();
			}
			
			break;
			
		case StateManager.GameState.Pda:
			if (Input.GetButtonDown ("Cancel") || Input.GetKeyDown (KeyCode.J)) {
				ChangeGameState (GameState.Playing);
			}
			break;
		}
	}

	void UpdateSuspicion ()
	{
		if (evidenceCount < 0) {
			ReduceSuspicion (5);
		} else if (evidenceCount > 1) {
			AddSuspicion (5);
		}
	}

	public void ResetGame ()
	{
		suspicionLevel = 0;
		detectionCount = 0;
		evidenceCount = 0;
		ClearAllFlags ();
		ballStates [0] = BALL_AVAILABLE;
		ballStates [1] = BALL_AVAILABLE;
	}

	public void ModifySuspicion (int amount = 1)
	{
		suspicionLevel = Mathf.Clamp (suspicionLevel + amount, 0, MAXIMUM_SUSPICION_LEVEL);
	}

	public void ReduceSuspicion (int amount = 1)
	{
		ModifySuspicion (-amount);
	}
	
	public void AddSuspicion (int amount = 1)
	{
		ModifySuspicion (amount);
	}
	
	public void ReduceDetection (string detectionName, int amount = 1)
	{
		if (detected.ContainsKey (detectionName)) {
			//	Debug.Log ("Remove " + detectionName);
			detected.Remove (detectionName);
			detectionCount = Mathf.Max (detectionCount - amount, 0);
		}
	}
	
	public void AddDetection (string detectionName, int amount = 1)
	{
		//Debug.Log ("detected.ContainsKey(detectionName)=" + detected.ContainsKey (detectionName));

		if (!detected.ContainsKey (detectionName)) {
			//Debug.Log ("Add " + detectionName);
			detected.Add (detectionName, detectionName);
			detectionCount = detectionCount + amount;
		}
	}

	public int GetSuspicion ()
	{
		return suspicionLevel;
	}

	private void HidePanel (GameObject panel)
	{
		if (panel == null) {
			return;
		}
		CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup> ();
		if (canvasGroup == null) {
			return;
		}

		canvasGroup.alpha = 0f;
	}
	
	private void ShowPanel (GameObject panel)
	{
		if (panel == null) {
			return;
		}
		CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup> ();
		if (canvasGroup == null) {
			return;
		}
		
		canvasGroup.alpha = 1f;
	}
	
	public void ChangeGameState (GameState newState)
	{
		if (newState == currentState) {
			return;
		}

		// Clear out the old state
		switch (currentState) {
		case GameState.Briefing:
			HidePanel (briefingPanel);
			break;
		case GameState.Pda:
			HidePanel (pdaPanel);
			break;
		case GameState.Dialog:
			HidePanel (dialogPanel);
			break;
		case GameState.Playing:
			Pause ();
			break;
		}

		// Activate the new state
		switch (newState) {
		case GameState.Briefing:
			ShowPanel (briefingPanel);
			break;
		case GameState.Pda:
			ShowPanel (pdaPanel);
			break;
		case GameState.Dialog:
			ShowPanel (dialogPanel);
			break;
		case GameState.Playing:
			Play ();
			break;
		}
		currentState = newState;
	}

	public bool IsPlaying ()
	{
		return currentState == GameState.Playing;
	}

	public void SetFlag (string flag)
	{
		flags.Add (flag);
	}

	public void ClearFlag (string flag)
	{
		flags.Remove (flag);
	}
	
	public void ClearAllFlags ()
	{
		flags.Clear ();
	}
	
	public bool HasFlag (string flag)
	{
		return flags.Contains (flag);
	}

	public void PrintFlags ()
	{
		foreach (string flag in flags) {
			Debug.Log (flag);
		}
	}

	public bool CompletedEvidence ()
	{
		foreach (string evidence in StateManager.EVIDENCES) {
			if (!HasFlag (evidence + "Removed")) {
				return false;
			}
		}
		return true;
	}
	
	public void Pause ()
	{
		if (paused) {
			return;
		}

		timeScale = Time.timeScale;
		Time.timeScale = 0f;
		paused = true;
	}

	public void Play ()
	{
		if (!paused) {
			return;
		}

		Time.timeScale = 1f;
		paused = false;
	}

	public bool IsPaused ()
	{
		return paused;
	}

	public void TurnOnGameOverPanel ()
	{
		gameOverPanel.SetActive (true);
	}

	public void TurnOffGameOverPanel ()
	{
		gameOverPanel.SetActive (false);
	}
}
