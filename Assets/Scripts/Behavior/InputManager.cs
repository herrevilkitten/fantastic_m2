using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public StateManager stateManager;
	public CursorManager cursorManager;
	public Image crosshairs;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("1")) {
			Application.LoadLevel (0);
		} else if (Input.GetKey ("2")) {
			Application.LoadLevel (1);
		} else if (Input.GetKey ("3")) {
			Application.LoadLevel (2);
		} else if (Input.GetKey ("4")) {
			Application.LoadLevel (3);
		}

		if (Input.GetButtonDown ("Cancel")) {
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetButtonDown ("Toggle Camera")) {
			if (stateManager.cameraMode == StateManager.CameraMode.Fixed) {
				stateManager.cameraMode = StateManager.CameraMode.Floating;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				crosshairs.enabled = false;
				cursorManager.DefaultCursor ();
			} else {
				stateManager.cameraMode = StateManager.CameraMode.Fixed;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				crosshairs.enabled = true;
				cursorManager.CrosshairsCursor ();
			}
		}
	}
}
