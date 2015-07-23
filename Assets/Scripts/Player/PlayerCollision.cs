using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
	const int TERRAIN_LAYER = 8;

	public float defaultForce = 3f;

	PlayerMovement movement;
	CharacterCollisionHandler[] collisionHandlers = {};

	// Use this for initialization
	void Start ()
	{
		movement = GetComponent<PlayerMovement> ();
		collisionHandlers = GetComponents<CharacterCollisionHandler> ();

		foreach (CharacterCollisionHandler collisionHandler in collisionHandlers) {
			Debug.Log ("Collision Handler: " + collisionHandler);
		}
	}

	void Initialize ()
	{
		Start ();
	}
	
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		// Layer 8 is terrain
		if (hit.collider.gameObject.layer == TERRAIN_LAYER) {
			return;
		}

		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
//		Debug.Log ("Controller collided with " + hit.collider + " at " + hit.moveDirection);
		
//		if (hit.moveDirection.y < -0.3F)
//			return;

		float force = defaultForce;
		if (movement != null) {
			force = movement.getCurrentSpeed () * movement.runningSpeed;
		}

		if (collisionHandlers != null) {
			foreach (CharacterCollisionHandler collisionHandler in collisionHandlers) {
//				Debug.Log ("Invoking " + collisionHandler + " with (" + hit + ", " + force + ")");
				bool stop = collisionHandler.handleCollision (hit, body, force);
				if (stop) {
					break;
				}
			}
		}
	}
}
