using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StateManager : MonoBehaviour
{
	public static Image crosshairs;

	public enum CameraMode
	{
		Fixed,
		Floating
	}

	public static bool knowsAboutYukMountain = false;
	public static bool canPassBarrier = false;
	public static CameraMode cameraMode = CameraMode.Floating;
	static float timeScale;
	static bool paused = false;

	static StateManager ()
	{
		crosshairs = GameObject.Find ("FirstPersonCrosshairs").GetComponent<Image> ();
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
			crosshairs.enabled = false;
			CursorManager.DefaultCursor ();
		} else {
			StateManager.cameraMode = StateManager.CameraMode.Fixed;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			crosshairs.enabled = true;
			CursorManager.CrosshairsCursor ();
		}
	}
}
