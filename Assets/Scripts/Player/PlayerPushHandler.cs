using UnityEngine;
using System.Collections;

public class PlayerPushHandler : MonoBehaviour, CharacterCollisionHandler
{
	public bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force)
	{
		Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
//		body.velocity = pushDir * force;
		body.AddForce (pushDir * force);
		return false;
	}

}
