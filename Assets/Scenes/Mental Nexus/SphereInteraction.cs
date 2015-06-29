using UnityEngine;
using System.Collections;

public class SphereInteraction : UsableObject
{
	override public void OnInteractContinuous (GameObject actor, bool changed)
	{
		Rigidbody sphereBody = GetComponent<Rigidbody> ();
		sphereBody.AddForce (actor.transform.forward * 20f);
	}
}
