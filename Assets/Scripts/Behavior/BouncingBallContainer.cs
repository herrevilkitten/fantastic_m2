using UnityEngine;
using System.Collections;

public class BouncingBallContainer : MonoBehaviour
{
	void OnTriggerExit (Collider other)
	{
		other.attachedRigidbody.velocity = -other.attachedRigidbody.velocity * .5f;
	}
}
