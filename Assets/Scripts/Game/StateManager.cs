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
	public const string EVIDENCE_KEYS = "keys";
	public const string EVIDENCE_FOOTPRINT = "footprint";
	public const string EVIDENCE_NECKLACE = "necklace";

	public const int BALL_THROWN = 2;
	public const int BALL_THROWING = 1;
	public const int BALL_AVAILABLE = 0;

	public static int[] ballStates = { BALL_AVAILABLE, BALL_AVAILABLE };
	public static string[] ballNames = { "Ball1", "Ball2" };

	private static Dictionary<string, string> detected = new Dictionary<string, string> ();

	public GameObject[] targets;

	public static string[] EVIDENCES = {
		EVIDENCE_KNIFE,
		EVIDENCE_PHONE,
		EVIDENCE_HANDPRINT,
		EVIDENCE_WALLET,
		EVIDENCE_KEYS,
		EVIDENCE_FOOTPRINT,
		EVIDENCE_NECKLACE
	};

	public enum CameraMode
	{
		Fixed,
		Floating
	}

	public enum GameState
	{
		Title,
		Settings,
		Credits,
		Journal,
		Playing
	}

	public static CameraMode cameraMode = CameraMode.Floating;
	public static int suspicionLevel = 0;
	public static int detectionCount = 0;
	public static int evidenceCount = 0;
	static float timeScale;
	static bool paused = false;
	static HashSet<string> flags = new HashSet<string> ();

	public GameObject titlePanel;
	public GameObject logoPanel;
	public GameObject settingsPanel;
	public GameObject creditsPanel;
	public GameObject journalPanel;
	public GameObject gamePanel;
	public GameObject flybyCamera;
	public GameObject gameOverPanel;

	public Image crosshairs;

	public static StateManager stateManager;

	void Awake ()
	{
		StateManager.stateManager = this;
		StateManager.ChangeGameState (GameState.Title);
		StateManager.ResetGame ();

		InvokeRepeating ("UpdateSuspicion", 0f, 1.0f);
	}

	void UpdateSuspicion ()
	{
		if (evidenceCount < 0) {
			ReduceSuspicion (5);
		} else if (evidenceCount > 1) {
			AddSuspicion (5);
		}
	}

	public static void ResetGame ()
	{
		StateManager.suspicionLevel = 0;
		StateManager.detectionCount = 0;
		StateManager.evidenceCount = 0;
		StateManager.ClearAllFlags ();
		ballStates [0] = BALL_AVAILABLE;
		ballStates [1] = BALL_AVAILABLE;
	}

	public static void ModifySuspicion (int amount = 1)
	{
		suspicionLevel = Mathf.Clamp (suspicionLevel + amount, 0, MAXIMUM_SUSPICION_LEVEL);
	}

	public static void ReduceSuspicion (int amount = 1)
	{
		ModifySuspicion (-amount);
	}
	
	public static void AddSuspicion (int amount = 1)
	{
		ModifySuspicion (amount);
	}
	
	public static void ReduceDetection (string detectionName, int amount = 1)
	{
		if (detected.ContainsKey (detectionName)) {
			//	Debug.Log ("Remove " + detectionName);
			detected.Remove (detectionName);
			detectionCount = Mathf.Max (detectionCount - amount, 0);
		}
	}
	
	public static void AddDetection (string detectionName, int amount = 1)
	{
		//Debug.Log ("detected.ContainsKey(detectionName)=" + detected.ContainsKey (detectionName));

		if (!detected.ContainsKey (detectionName)) {
			//Debug.Log ("Add " + detectionName);
			detected.Add (detectionName, detectionName);
			detectionCount = detectionCount + amount;
		}
	}

	public static int GetSuspicion ()
	{
		return suspicionLevel;
	}
	
	public static GameState currentState = GameState.Title;
	public static void ChangeGameState (GameState newState)
	{
		if (newState == currentState) {
			return;
		}

		// Clear out the old state
		switch (currentState) {
		case GameState.Title:
			stateManager.logoPanel.SetActive (false);
			stateManager.titlePanel.SetActive (false);
			break;
		case GameState.Settings:
			stateManager.settingsPanel.SetActive (false);
			stateManager.titlePanel.SetActive (false);
			break;
		case GameState.Credits:
			stateManager.creditsPanel.SetActive (false);
			stateManager.titlePanel.SetActive (false);
			break;
		case GameState.Journal:
			stateManager.journalPanel.SetActive (false);
			break;
		case GameState.Playing:
			Pause ();
			break;
		}

		// Activate the new state
		switch (newState) {
		case GameState.Title:
			stateManager.logoPanel.SetActive (true);
			stateManager.titlePanel.SetActive (true);
			break;
		case GameState.Settings:
			stateManager.settingsPanel.SetActive (true);
			stateManager.titlePanel.SetActive (true);
			break;
		case GameState.Credits:
			stateManager.creditsPanel.SetActive (true);
			stateManager.titlePanel.SetActive (true);
			break;
		case GameState.Journal:
			stateManager.journalPanel.GetComponent<ShowJournal> ().UpdateText ();
			stateManager.journalPanel.SetActive (true);
			break;
		case GameState.Playing:
			stateManager.flybyCamera.SetActive (false);
			stateManager.gamePanel.SetActive (true);
			Play ();
			break;
		}
		currentState = newState;
	}

	public static bool IsPlaying ()
	{
		return currentState == GameState.Playing;
	}

	public static void SetFlag (string flag)
	{
		flags.Add (flag);
	}

	public static void ClearFlag (string flag)
	{
		flags.Remove (flag);
	}
	
	public static void ClearAllFlags ()
	{
		flags.Clear ();
	}
	
	public static bool HasFlag (string flag)
	{
		return flags.Contains (flag);
	}

	public static void PrintFlags ()
	{
		foreach (string flag in flags) {
			Debug.Log (flag);
		}
	}

	public static bool CompletedEvidence ()
	{
		foreach (string evidence in StateManager.EVIDENCES) {
			if (!HasFlag (evidence + "Removed")) {
				return false;
			}
		}
		return true;
	}
	
	public static void Pause ()
	{
		if (paused) {
			return;
		}

		timeScale = Time.timeScale;
		Time.timeScale = 0f;
		paused = true;
	}

	public static void Play ()
	{
		if (!paused) {
			return;
		}

		Time.timeScale = 1f;
		paused = false;
	}

	public static bool IsPaused ()
	{
		return paused;
	}

	public static void ToggleCamera ()
	{
		if (StateManager.cameraMode == StateManager.CameraMode.Fixed) {
			StateManager.cameraMode = StateManager.CameraMode.Floating;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			if (stateManager.crosshairs != null) {
				stateManager.crosshairs.enabled = false;
			}
			CursorManager.DefaultCursor ();
		} else {
			StateManager.cameraMode = StateManager.CameraMode.Fixed;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			if (stateManager.crosshairs != null) {
				stateManager.crosshairs.enabled = true;
			}
			CursorManager.CrosshairsCursor ();
		}
	}

	public static void TurnOnGameOverPanel ()
	{
		stateManager.gameOverPanel.SetActive (true);
	}

	public static void TurnOffGameOverPanel ()
	{
		stateManager.gameOverPanel.SetActive (false);
	}
}
