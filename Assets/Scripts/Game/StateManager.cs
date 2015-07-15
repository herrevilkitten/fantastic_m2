using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StateManager : MonoBehaviour
{
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

	public static bool knowsAboutYukMountain = false;
	public static bool canPassBarrier = false;
	public static CameraMode cameraMode = CameraMode.Floating;
	static float timeScale;
	static bool paused = false;
	static HashSet<string> flags = new HashSet<string> ();

	public  GameObject titlePanel;
	public GameObject logoPanel;
	public  GameObject settingsPanel;
	public  GameObject creditsPanel;
	public  GameObject journalPanel;
	public Image crosshairs;

	public static StateManager stateManager;

	void Start ()
	{
		StateManager.stateManager = this;
	}

	static GameState currentState = GameState.Title;
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
			stateManager.journalPanel.SetActive (true);
			break;
		case GameState.Playing:
			Play ();
			break;
		}
		currentState = newState;
	}

	public static void SetFlag (string flag)
	{
		flags.Add (flag);
	}

	public static void ClearFlag (string flag)
	{
		flags.Remove (flag);
	}
	
	public static bool HasFlag (string flag)
	{
		return flags.Contains (flag);
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

		Time.timeScale = timeScale;
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
}
