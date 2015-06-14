using UnityEngine;
using System.Collections;

public class BarricadeMover : MonoBehaviour {
	public float pushPower;

	void OnControllerColliderHit(ControllerColliderHit hit) {
		print ("Detected collision between " + gameObject.name + " and " + hit.collider.name);
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;

		print ("body is not null and not kinematic enabled");

		if (hit.moveDirection.y < -0.3F)
			return;

		print ("direction is x");

		body.velocity = transform.TransformDirection (Vector3.forward * 100);
	}
}
