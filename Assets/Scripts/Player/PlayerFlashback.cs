using UnityEngine;
using System.Collections;

public class PlayerFlashback : MonoBehaviour {
	
	public AudioClip screamClip;
	
	AudioSource audioSource;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = screamClip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {

		if (hit.collider.tag == "Flashback") {
			
			Invoke ("FlashbackMoment", 0.5f);
			
		}
	}
	
	void FlashbackMoment() {
		SetKinematic (false);
		GetComponent<Animator> ().enabled = false;
		
	}
	
	void SetKinematic(bool newValue)
	{
		//animationClip.Play ();
		audioSource.volume = 0.3f;
		audioSource.clip = screamClip;
		audioSource.Play ();
		
		Rigidbody[] bodies=GetComponentsInChildren<Rigidbody>();
		
		foreach (Rigidbody rigidParts in bodies) {
			rigidParts.isKinematic=newValue;
		}
	}
}
