using UnityEngine;
using System.Collections;

public class BouncingBallContainer : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerExit (Collider other)
	{
		Debug.Log ("Ball Barrier: " + other);
		other.attachedRigidbody.velocity = -other.attachedRigidbody.velocity * .5f;
	}
}
