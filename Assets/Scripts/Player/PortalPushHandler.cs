using UnityEngine;
using System.Collections;

public class PortalPushHandler : MonoBehaviour, CharacterCollisionHandler
{
	public bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force)
	{
		return true;
	}
}
