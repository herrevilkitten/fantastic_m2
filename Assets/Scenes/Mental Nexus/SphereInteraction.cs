using UnityEngine;
using System.Collections;

public class SphereInteraction : InteractiveObject
{
	override public void Interact (GameObject actor)
	{
		Rigidbody sphereBody = GetComponent<Rigidbody> ();
		sphereBody.AddForce (actor.transform.forward * 20f);
	}
}
