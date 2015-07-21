using UnityEngine;
using System.Collections;

public class PushInteraction : UsableObject
{
	override public void OnInteractContinuous (GameObject actor, bool changed)
	{
		Debug.Log ("Interacting with " + gameObject + " direction: " + actor.transform.forward);
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (actor.transform.forward * 20f * rigidBody.mass);
	}
}