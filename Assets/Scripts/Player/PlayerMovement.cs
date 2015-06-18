using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	public float backwardsSpeed = 2.0f;
	public float walkingSpeed = 3.0f;
	public float runningSpeed = 7.5f;
	public float turningSpeed = 60f;
	public float accelerationSpeed = .3f;
	public float movementMultiplier = 15f;

	private float currentSpeed = 0.0f;
	private float sidewaysSpeed = 0.0f;
	private float direction = 1f;
	private bool jumping = false;

	private AnimatorStateInfo currentBaseState;

	Animator animator;
	Rigidbody playerRigidBody;
	CharacterController controller;
	Rigidbody rigidBody;

	//Accessor for Terrain Sound script
	public float getCurrentSpeed ()
	{
		return currentSpeed / runningSpeed;
	}

	void Start ()
	{
		animator = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}

	void Update ()
	{
		currentBaseState = animator.GetCurrentAnimatorStateInfo (0);

		if (jumping) {
			jumping = false;
			animator.SetBool ("IsJumping", false);
		}

		if (Input.GetButton ("Jump")) {
			animator.SetBool ("IsJumping", true);
			jumping = true;
			return;
		}

		if(currentBaseState.nameHash == Animator.StringToHash("Base Layer.jump_over"))
		{
			controller.height = animator.GetFloat("CharacterHeight");
			
			// Raycast down from the center of the character.. 
			Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
			RaycastHit hitInfo = new RaycastHit();
			
			if (Physics.Raycast(ray, out hitInfo))
			{
				if (hitInfo.distance > 2.5f)
				{
					
					// MatchTarget allows us to take over animation and smoothly transition our character towards a location - the hit point from the ray.
					// Here we're telling the Root of the character to only be influenced on the Y axis (MatchTargetWeightMask) and only occur between 0.35 and 0.5
					// of the timeline of our animation clip
					animator.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.2f, 0.55f);
				}
			}
		}

		// http://answers.unity3d.com/questions/543421/gradual-acceleration.html
		Boolean running = Input.GetButton ("Run");

		float rotate = Input.GetAxis ("Horizontal") * turningSpeed * Time.deltaTime;
		if (running) {
			rotate = rotate * 2f;
		}
		transform.Rotate (0, rotate, 0);
		animator.SetFloat ("TSpeed", rotate);

		float strafe = 0;
		if (Input.GetButton ("Left Strafe")) {
			strafe = -1;
		} else if (Input.GetButton ("Right Strafe")) {
			strafe = 1;
		}
		animator.SetFloat ("HSpeed", strafe);

		float movement = Input.GetAxis ("Vertical");
		Vector3 vector = Vector3.zero;
		if (movement < 0f) {
			// Going backwards
			currentSpeed = Mathf.Min (backwardsSpeed, currentSpeed + accelerationSpeed);
			direction = -1f;
		} else if (movement > 0f) {
			direction = 1f;
			// Going forward
			if (running) {
				currentSpeed = Mathf.Min (runningSpeed, (currentSpeed + accelerationSpeed));
				//controller.slopeLimit = 60;
			} else {
				//controller.slopeLimit = 45;
				if (currentSpeed > walkingSpeed) {
					// Decelerate
					currentSpeed = Mathf.Max (walkingSpeed, currentSpeed - accelerationSpeed);
				} else {
					// Accelerate / maintain
					currentSpeed = Mathf.Min (walkingSpeed, currentSpeed + accelerationSpeed);
				}
			}
		} else {
			// Player is not moving, so slow down to 0
			currentSpeed = Mathf.Max (0f, (currentSpeed - accelerationSpeed));
		}

		if (direction > 0) {
			vector = transform.TransformDirection (Vector3.forward);
		} else {
			vector = transform.TransformDirection (Vector3.back);
		}

		if (currentSpeed > 0f) {
		} else {
			direction = 1f;
		}

		animator.SetFloat ("VSpeed", currentSpeed * direction);
		animator.SetBool ("IsMoving", currentSpeed != 0f || rotate != 0f);
		animator.SetBool ("IsStrafing", strafe != 0f);
	}
}
