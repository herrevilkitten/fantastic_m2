using UnityEngine;
using System.Collections;

public class ForceTrigger : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerStay (Collider other)
	{
		//Debug.Log ("Collision with " + other);
		other.attachedRigidbody.AddForce (Vector3.up * Random.Range (360f, 600f), ForceMode.Force);
	}
}
