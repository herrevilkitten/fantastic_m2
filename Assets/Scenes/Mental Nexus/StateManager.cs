using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{
	public enum CameraMode
	{
		Fixed,
		Floating
	}

	public bool knowsAboutYukMountain = false;
	public bool canPassBarrier = false;
	public CameraMode cameraMode = CameraMode.Floating;
}
