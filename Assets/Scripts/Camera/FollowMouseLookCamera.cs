using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowMouseLookCamera : MonoBehaviour
{
	public GameObject eyePosition;
	public GameObject followPosition;
	Text cameraStatusText;
	Transform cameraPosition;
	Vector3 followOffset;
	Vector3 eyeOffset;
	float yPosition;
	float xPosition;
	float mouseX;
	float mouseY;
	bool mouseDown;

	// Use this for initialization
	void Start ()
	{
		if (eyePosition == null) {
			eyePosition = transform.parent.FindChild ("EyeCameraPlaceholder").gameObject;
		}

		if (followPosition == null) {
			followPosition = transform.parent.FindChild ("FollowCameraPlaceholder").gameObject;
		}

		followOffset = eyePosition.transform.position - followPosition.transform.position;
		eyeOffset = Vector3.zero;

		followPosition.transform.LookAt (eyePosition.transform);

		yPosition = followPosition.transform.rotation.y;
		xPosition = followPosition.transform.rotation.x;

		transform.position = followPosition.transform.position;
		transform.LookAt (eyePosition.transform);

		cameraStatusText = GameObject.Find ("CameraStatusText").gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame	
	void LateUpdate ()
	{
		bool looking = Input.GetButton ("Mouse Look");
		float upDown = Input.GetAxis ("Mouse Y") * -5f;
		float leftRight = Input.GetAxis ("Mouse X") * 5f;

		if (StateManager.cameraMode == StateManager.CameraMode.Fixed) {
			if (Input.GetButton ("Run")) {
				transform.localPosition = eyePosition.transform.localPosition + new Vector3 (0f, -.1f, .04f);
			} else {
				transform.localPosition = eyePosition.transform.localPosition;
			}
			yPosition = yPosition + upDown;
			Quaternion rotation = Quaternion.Euler (yPosition, 0, 0);
			transform.localRotation = rotation;
//			transform.localPosition = cameraPosition.transform.localPosition - (rotation * eyeOffset);
		} else {
			// Use the placeholder to get the default angle to the target
			// First, look at the target
			followPosition.transform.LookAt (eyePosition.transform);
			
			// Then get the x and y angles
			if (looking) {
				if (!mouseDown) {
					mouseX = Input.mousePosition.x;
					mouseY = Input.mousePosition.y;
					mouseDown = true;
					Cursor.lockState = CursorLockMode.Locked;
				}
				yPosition = yPosition + upDown;
				xPosition = xPosition + leftRight;
				Quaternion rotation = Quaternion.Euler (yPosition, xPosition, 0);
				transform.localPosition = eyePosition.transform.localPosition - (rotation * followOffset);
			} else {
				Cursor.lockState = CursorLockMode.None;
				mouseDown = false;
				Cursor.visible = true;
				//			Cursor.lockState = CursorLockMode.None;
				GameObject playerObject = transform.parent.gameObject;
				Animator playerAnimator = playerObject.GetComponent<Animator> ();
				if (playerAnimator.GetBool ("IsMoving")) {
					transform.position = Vector3.Slerp (transform.position, followPosition.transform.position, Time.timeScale * .1f);
					yPosition = followPosition.transform.rotation.y;
					xPosition = followPosition.transform.rotation.x;
				}
			}

			RaycastHit hit;
			if (Physics.Linecast (eyePosition.transform.position, transform.position, out hit)) {
				if (hit.collider.transform != transform.parent) {
					transform.position = hit.point;
				}
			}

			if (cameraStatusText != null) {
				cameraStatusText.text = 
				"Looking at: " + eyePosition + "\n" +
					"From: " + followPosition + "\n" +
					"Mouse Y: " + upDown + "\n"
					+ "Mouse X: " + leftRight + "\n"
				//+ "MouseDown: " + looking + "\n"
					+ "Follow Cam:\n   " + followPosition.transform.position + "/" + "\n   " + followPosition.transform.eulerAngles + "\n"
					+ "Main Cam:\n   " + transform.position + "/" + "\n" + "   " + transform.eulerAngles + "\n"
					+ "Mouse: " + xPosition + ", " + yPosition + "\n"
					+ "Collision: " + hit.point + "\n   With:" + hit.collider;
			}
		
			transform.LookAt (eyePosition.transform);
		}
	}
}
