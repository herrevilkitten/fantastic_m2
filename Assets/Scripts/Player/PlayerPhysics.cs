﻿using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	public float pushPower = 2.0f;

	void OnControllerColliderHit (ControllerColliderHit hit) { 

		Rigidbody body = hit.collider.attachedRigidbody;
		Vector3 pushDir;
		
		// no rigidbody
		if (body == null || body.isKinematic) { return; }
		
		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3) { return; }
		
		// Calculate push direction from move direction,
		// we only push objects to the sides never up and down
		pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		
		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.
		
		// Apply the push
		body.velocity = pushDir * pushPower;
	}
}
