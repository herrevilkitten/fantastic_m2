using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{
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
}
