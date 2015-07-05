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
}
