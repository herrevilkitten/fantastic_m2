using UnityEngine;
using System.Collections;

public class SphereInteraction : MonoBehaviour, InteractiveObject
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Interact (GameObject actor)
	{
		Rigidbody sphereBody = GetComponent<Rigidbody> ();
		sphereBody.AddForce (Vector3.forward * 20f);
	}
}
