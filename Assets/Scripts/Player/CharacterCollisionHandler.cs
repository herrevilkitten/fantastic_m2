using UnityEngine;
using System.Collections;

public interface CharacterCollisionHandler
{
	bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force);
}
