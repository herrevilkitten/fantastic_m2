using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowMouseLookCamera : MonoBehaviour
{
	public GameObject target;
	public GameObject placeholder;
	public CursorManager cursorManager;
	public Text statusText;
	Vector3 offset;
	float yPosition;
	float xPosition;
	float mouseX;
	float mouseY;
	bool mouseDown;

	// Use this for initialization
	void Start ()
	{
		offset = target.transform.position - placeholder.transform.position;

		placeholder.transform.LookAt (target.transform);

		yPosition = placeholder.transform.rotation.y;
		xPosition = placeholder.transform.rotation.x;

		transform.position = placeholder.transform.position;
		transform.LookAt (target.transform);
	}
	
	// Update is called once per frame	
	void LateUpdate ()
	{
		bool looking = Input.GetButton ("Mouse Look");
		float upDown = Input.GetAxis ("Mouse Y") * -5f;
		float leftRight = Input.GetAxis ("Mouse X") * 5f;

		// Use the placeholder to get the default angle to the target
		// First, look at the target
		placeholder.transform.LookAt (target.transform);
		
		// Then get the x and y angles
		if (looking) {
			if (!mouseDown) {
				mouseX = Input.mousePosition.x;
				mouseY = Input.mousePosition.y;
				mouseDown = true;
				Cursor.lockState = CursorLockMode.Confined;
//				Cursor.visible = false;
			}
//			Cursor.lockState = CursorLockMode.Locked;
			yPosition = yPosition + upDown;
			xPosition = xPosition + leftRight;
			Quaternion rotation = Quaternion.Euler (yPosition, xPosition, 0);
			transform.localPosition = target.transform.localPosition - (rotation * offset);
		} else {
			Cursor.lockState = CursorLockMode.None;
			mouseDown = false;
			Cursor.visible = true;
			//			Cursor.lockState = CursorLockMode.None;
			GameObject playerObject = transform.parent.gameObject;
			Animator playerAnimator = playerObject.GetComponent<Animator> ();
			if (playerAnimator.GetBool ("IsMoving")) {
				transform.position = Vector3.Slerp (transform.position, placeholder.transform.position, Time.timeScale * .1f);
				yPosition = placeholder.transform.rotation.y;
				xPosition = placeholder.transform.rotation.x;
			}
		}

		RaycastHit hit;
		if (Physics.Linecast (target.transform.position, transform.position, out hit)) {
			if (hit.collider.transform != transform.parent) {
				transform.position = hit.point;
			}
		}

		if (statusText != null) {
			statusText.text = 
				"Looking at: " + target + "\n" +
				"From: " + placeholder + "\n" +
				"Mouse Y: " + upDown + "\n"
				+ "Mouse X: " + leftRight + "\n"
			//+ "MouseDown: " + looking + "\n"
				+ "Follow Cam:\n   " + placeholder.transform.position + "/" + "\n   " + placeholder.transform.eulerAngles + "\n"
				+ "Main Cam:\n   " + transform.position + "/" + "\n" + "   " + transform.eulerAngles + "\n"
				+ "Mouse: " + xPosition + ", " + yPosition + "\n"
				+ "Collision: " + hit.point + "\n   With:" + hit.collider;
		}
		
		transform.LookAt (target.transform);
	}

	void OnGUI2 ()
	{
		if (mouseDown) {
			Rect mousePosition = new Rect (mouseX, mouseY, 32, 32);
			Texture cursor = cursorManager.GetCursorTexture ();
			Debug.Log ("Cursor is " + cursor);
			Debug.Log ("Cursor position is " + mousePosition);
			GUI.DrawTexture (mousePosition,
			                 cursor,
			                 ScaleMode.ScaleToFit, true, 0);

		}
	}
}
