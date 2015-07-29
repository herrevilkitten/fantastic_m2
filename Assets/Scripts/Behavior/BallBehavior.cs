using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	private Transform player;
	public float throwForce = 1;
	bool released = false;
	float timeThrown;

	public void ReleaseMe(Transform player, Animator animator) {
		Rigidbody ballRB = GetComponent<Rigidbody> ();
		ballRB.useGravity = true;

		float velocity = Mathf.Sqrt (6.5f * Physics.gravity.magnitude);

		Vector3 direction = new Vector3 ();
		direction.x = player.forward.x + (-0.3f);
		direction.y = player.forward.y;
		direction.z = player.forward.z;


		Vector3 vel = velocity * direction;

		ballRB.velocity = vel;
		//ballRB.AddForce (transform.forward * throwForce);
		released = true;
		timeThrown = Time.time;
	}

	public float GetThrownTime() {
		return timeThrown;
	}

	public void OnCollisionEnter(Collision collision) {
		if (released) {
			Debug.Log ("get ball again");
		}
	}
}
