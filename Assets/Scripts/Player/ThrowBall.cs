using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour {
	public GameObject ballToThrow;
	private GameObject ball;
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("t") && !animator.GetBool("IsThrowing")) {
			Animator anim = GetComponent<Animator>();
			anim.SetBool("IsThrowing", true);
			//Invoke ("StopThrowing", 0.25f);
		}
	}

	public void ShowBall() {
		Debug.Log ("Called Show Me" + Time.time);
		Vector3 position = new Vector3();
		position.x = this.transform.position.x + 0.20f;
		position.y = this.transform.position.y + 1.66f;
		position.z = this.transform.position.z + 0.30f;

		ball = (GameObject)Instantiate (ballToThrow, position, this.transform.rotation);

		Rigidbody ballRB = ball.GetComponent<Rigidbody> ();
		ballRB.useGravity = false;
		ball.transform.position = position; 

		animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
		animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1); 
		animator.SetIKPosition(AvatarIKGoal.RightHand, ball.transform.position);
		animator.SetIKRotation(AvatarIKGoal.RightHand, ball.transform.rotation);

	}
	
	public void ReleaseBall() {
		Debug.Log ("Called Release Me" + Time.time);

		BallBehavior behavior = ball.GetComponent<BallBehavior> ();
		behavior.ReleaseMe (transform, animator);

		animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
		animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0);
	}

	public void StopThrow() {
		animator.SetBool ("IsThrowing", false);

	}
}
