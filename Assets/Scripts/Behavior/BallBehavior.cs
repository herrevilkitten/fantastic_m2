using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	private Transform player;
	public float throwForce = 1;
	bool hasPlayer = false;

	void OnTriggerEnter(Collider other)
	{
		hasPlayer = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		hasPlayer = false;
	}	


	public void ReleaseMe(Transform player, Animator animator) {
		Rigidbody ballRB = GetComponent<Rigidbody> ();
		ballRB.useGravity = true;

		float velocity = Mathf.Sqrt (15f * Physics.gravity.magnitude);
		Vector3 vel = velocity * player.forward;

		ballRB.velocity = vel;
		//ballRB.AddForce (transform.forward * throwForce);


	}
}
