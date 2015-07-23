using UnityEngine;
using System.Collections;

public class PushInteraction : UsableObject
{
	override public void OnInteractContinuous (GameObject actor, bool changed)
	{
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (actor.transform.forward * 20f * rigidBody.mass);
	}
}