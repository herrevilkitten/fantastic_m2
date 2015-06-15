﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowMouseLookCamera : MonoBehaviour
{
	public GameObject target;
	public GameObject placeholder;
	public Text statusText;
	Vector3 offset;
	float yPosition;
	float xPosition;

	// Use this for initialization
	void Start ()
	{
		offset = target.transform.position - placeholder.transform.position;

		placeholder.transform.LookAt (target.transform);

		yPosition = placeholder.transform.eulerAngles.y;
		xPosition = placeholder.transform.eulerAngles.x;

		Quaternion rotation = Quaternion.Euler (yPosition, xPosition, 0);

		transform.position = placeholder.transform.position;// - (rotation * offset);
		transform.LookAt (target.transform);
	}
	
	// Update is called once per frame	
	void LateUpdate ()
	{
		bool looking = Input.GetButton ("Fire1");
		float upDown = Input.GetAxis ("Mouse Y") * -5f;
		float leftRight = Input.GetAxis ("Mouse X") * -5f;

		// Use the placeholder to get the default angle to the target
		// First, look at the target
		placeholder.transform.LookAt (target.transform);
		
		// Then get the x and y angles
		float desiredX = placeholder.transform.eulerAngles.x;
		float desiredY = placeholder.transform.eulerAngles.y;

		if (looking) {
			yPosition = yPosition + upDown;//Mathf.Clamp (yPosition + upDown, -45f, 45f);//Mathf.Max (-10f, Mathf.Min (10f, yPosition + upDown));
//		xPosition = Mathf.Clamp (xPosition + leftRight, -180f, 180f);//Mathf.Max (-10f, Mathf.Min (10f, yPosition + upDown));
			xPosition = xPosition + leftRight;
//		float desiredAngle = target.transform.eulerAngles.y;
//		Quaternion rotation = Quaternion.Euler (yPosition, desiredAngle, 0);
			Quaternion rotation = Quaternion.Euler (yPosition, xPosition, 0);
			transform.position = target.transform.position - (rotation * offset);
		} else {
			yPosition = desiredY; //Mathf.Lerp (yPosition, desiredY, Time.deltaTime);
			xPosition = desiredX; //Mathf.Lerp (xPosition, desiredX, Time.deltaTime);
			transform.position = placeholder.transform.position;// target.transform.position - (rotation * offset);
		}

		RaycastHit hit;
//		Debug.Log ("Testing for collision: " + target.transform.position + " " + transform.eulerAngles);
		//Debug.DrawLine (target.transform.position, transform.position);
		if (Physics.Linecast (target.transform.position, transform.position, out hit)) {
			if (hit.collider.tag != "Player") {
//				Debug.Log ("Camera collision at " + hit.collider + " " + hit.point + " " + hit.distance);
				transform.position = hit.point;
			}
		}

		statusText.text = "Mouse Y: " + upDown + "/" + yPosition + "\n"
			+ "Mouse X: " + leftRight + "/" + xPosition + "\n"
			+ "MouseDown: " + looking + "\n"
			+ "Follow Cam:\n   " + placeholder.transform.position + "/" + "\n   " + placeholder.transform.eulerAngles + "\n"
			+ "Main Cam:\n   " + transform.position + "/" + "\n" + "   " + transform.eulerAngles + "\n"
			+ "Collision: " + hit.point + "\n   With:" + hit.collider;
		
		transform.LookAt (target.transform);
	}
}
