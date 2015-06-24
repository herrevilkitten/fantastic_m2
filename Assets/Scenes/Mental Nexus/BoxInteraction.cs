using UnityEngine;
using System.Collections;

public class BoxInteraction : InteractiveObject
{
	override public void Interact (GameObject actor)
	{
		Rigidbody boxBody = GetComponent<Rigidbody> ();
		boxBody.velocity = transform.up * 1f;
//		boxBody.AddForce (transform.up * 10f);
	}
}
