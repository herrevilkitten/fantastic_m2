using UnityEngine;
using System.Collections;

public class BoxInteraction : ClickableObject
{
	bool isOpen = false;
	float target = 270f;

	void Update ()
	{
		Rigidbody boxBody = GetComponent<Rigidbody> ();
		float xAngle = transform.localEulerAngles.x - 270f;
		if (xAngle < 0f) {
			xAngle += 360f;
		}
		if (isOpen) {
			if (xAngle < 75f) {
				boxBody.AddForce (transform.up * 20f);
			} else {
				transform.localEulerAngles = new Vector3 (345f, transform.localEulerAngles.y, transform.localEulerAngles.z);
				boxBody.constraints = RigidbodyConstraints.FreezeRotation;
			}
		} else if (!isOpen) {
			if (xAngle > 0f) {
				boxBody.AddForce (-transform.up * 5f);
			} else {
				transform.localEulerAngles = new Vector3 (270f, transform.localEulerAngles.y, transform.localEulerAngles.z);
				boxBody.constraints = RigidbodyConstraints.FreezeRotation;
			}
		}
	}

	override public void OnInteractClick (GameObject actor)
	{
		Rigidbody boxBody = GetComponent<Rigidbody> ();
		boxBody.constraints = RigidbodyConstraints.None;
		isOpen = !isOpen;
		DialogManager.PopUp ("You " + (isOpen ? "open" : "close") + " the box.");
	}
}
