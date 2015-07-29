using UnityEngine;
using System.Collections;

public class PushInteraction : UsableObject
{
	override public void OnInteractContinuous (GameObject actor, bool changed)
	{
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		if (rigidBody == null) {
			rigidBody = GetComponentInParent<Rigidbody> ();
		}
		if (rigidBody == null) {
			return;
		}
		rigidBody.AddForce (actor.transform.forward * 20f * rigidBody.mass);
	}
}