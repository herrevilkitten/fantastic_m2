using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	public float pushPower = 10.0f;

	void OnControllerColliderHit (ControllerColliderHit hit) { 
		//Debug.Log ("detect a controller collider hit");
		Rigidbody body = hit.collider.attachedRigidbody;
		Vector3 pushDir;

		//Debug.Log ("body = " + (body==null));
		if (body!=null) 
			//Debug.Log ("body = " + (body.isKinematic));
		// no rigidbody
		if (body == null || body.isKinematic) { return; }

		//Debug.Log (hit.moveDirection);
		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3) { return; }

		if (body.tag == "Door") {
			//Debug.Log("Pushing door");
			body.AddForce(-transform.forward * 1000f, ForceMode.Acceleration);
			body.useGravity = true;
		} else {
			// Calculate push direction from move direction,
			// we only push objects to the sides never up and down
			pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
			
			// If you know how fast your character is trying to move,
			// then you can also multiply the push velocity by that.
			
			// Apply the push
			body.velocity = pushDir * pushPower;
		}
	}
}
