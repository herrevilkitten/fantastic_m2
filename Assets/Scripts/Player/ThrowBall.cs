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

			if (StateManager.ballStates[0] == StateManager.BALL_AVAILABLE) {
				StateManager.ballStates[0] = StateManager.BALL_THROWING;
				animator.SetBool("IsThrowing", true);
			} else if (StateManager.ballStates[1] == StateManager.BALL_AVAILABLE) {
				StateManager.ballStates[1] = StateManager.BALL_THROWING;
				animator.SetBool("IsThrowing", true);
			}
		}
	}

	public void ShowBall() {
		Debug.Log ("Called Show Me" + Time.time);
		Vector3 position = new Vector3();
		position.x = this.transform.position.x + 0.20f;
		position.y = this.transform.position.y + 1.66f;
		position.z = this.transform.position.z + 0.30f;

		ball = (GameObject)Instantiate (ballToThrow, position, this.transform.rotation);

		if (StateManager.ballStates[0] == StateManager.BALL_THROWING) {
			ball.name = StateManager.ballNames[0];
		} else if (StateManager.ballStates[1] == StateManager.BALL_THROWING) {
			ball.name = StateManager.ballNames[1];
		}

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
		if (StateManager.ballStates[0] == StateManager.BALL_THROWING) {
			StateManager.ballStates[0] = StateManager.BALL_THROWN;
		} else if (StateManager.ballStates[1] == StateManager.BALL_THROWING) {
			StateManager.ballStates[1] = StateManager.BALL_THROWN;
		}

	}
}
