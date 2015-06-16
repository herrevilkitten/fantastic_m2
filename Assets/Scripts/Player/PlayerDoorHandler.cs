using UnityEngine;
using System.Collections;

public class PlayerDoorHandler : MonoBehaviour, CharacterCollisionHandler
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force)
	{
		if (!body.tag.Contains ("Door")) {
			return false;
		}

		body.AddForce (-transform.forward * 1000f, ForceMode.Acceleration);
		body.useGravity = true;
		return true;
	}
}