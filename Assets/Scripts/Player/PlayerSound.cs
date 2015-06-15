using UnityEngine;
using System.Collections;
using System;

public class PlayerSound : MonoBehaviour {

	public AudioClip grassSteppingClip;
	public AudioClip pavementSteppingClip;
	public AudioClip gravelSteppingClip;

	string currentFloorTag = "";
	string previousFloorTag = "";
	AudioSource audioSource;


	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {

		if ((Input.GetAxis ("Vertical") != 0f) || (Input.GetAxis ("Horizontal") != 0f)) {
			currentFloorTag = GetFloorType();

//			Debug.Log ("floor tag=" + currentFloorTag);
			//Then you use the floorTag to choose the type of footstep
			if (currentFloorTag == "Pavement") {
				audioSource.clip = pavementSteppingClip;
				//Invoke ("StopClip", 2f);
			}
			if (currentFloorTag == "Grass") {
				audioSource.clip = grassSteppingClip;
			}

			if (currentFloorTag == "Gravel") {
				audioSource.clip = gravelSteppingClip;
			}

			audioSource.volume = 0.3f;

			
			if (!currentFloorTag.Equals(previousFloorTag)) {
				audioSource.Stop();
			}

			if (!audioSource.isPlaying) {
				previousFloorTag = currentFloorTag;
				audioSource.Play ();
			} 

		} else {
			
		}
	}

	private void StopClip() {
		if (audioSource.isPlaying) {
			audioSource.Stop ();
		}
	}

	private string GetFloorType() {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			return hit.collider.tag;
		}

		return "no floor";
	}

	/*
	void OnCollisionEnter(Collision collision){
		CharacterController controller = GetComponent<CharacterController>();

		float vel = controller.velocity.magnitude;
		Debug.Log ("controller = " + controller);
		Debug.Log ("controller = " + controller.isGrounded);
		if (controller.isGrounded && vel > 0.01){
			
			if(collision.gameObject.tag == "Pavement"){
				audioSource.clip = pavementSteppingClip;
				audioSource.volume = 4.0f;
				audioSource.pitch = 4.0f;
				audioSource.loop = true;
				audioSource.Play();
			}
			
			else if(collision.gameObject.tag == "Grass"){
				audioSource.clip = grassSteppingClip;
				audioSource.volume = 4.0f;
				audioSource.pitch = 4.0f;
				audioSource.loop = true;
				audioSource.Play();
			}

		}

	}
	*/

}
