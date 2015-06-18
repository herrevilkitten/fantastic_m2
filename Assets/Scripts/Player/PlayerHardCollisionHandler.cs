using UnityEngine;
using System.Collections;

public class PlayerHardCollisionHandler : MonoBehaviour, CharacterCollisionHandler
{
	AudioSource audioSource;
	public AudioClip hardHitClip;
	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force)
	{
		Debug.Log ("force=" + force);
		Debug.Log ("body.tag" + body.tag);
		if (body.tag.Contains ("Ooomph") && force > 17) {
			audioSource.clip = hardHitClip;
			audioSource.volume = 1f;
			audioSource.Play();
		}

		Debug.Log (GetComponent<CharacterController> ().velocity);
		if (body.tag.Contains ("Ice") && GetComponent<CharacterController>().velocity.magnitude > 1.1f) {

		}

		return true;
	}
}
