using UnityEngine;
using System.Collections;

public class PlayerGlassPushHandler : MonoBehaviour, CharacterCollisionHandler
{
	public AudioClip glassCubeAudio;

	AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force)
	{
		if (!hit.gameObject.tag.Contains ("GlassCube")) {
			return false;
		}

		if (glassCubeAudio != null) {
			audioSource.volume = force / 7.5f;
			audioSource.clip = glassCubeAudio;
			audioSource.Play ();
		}

		Vector3 pushDir = Vector3.up * .05f * force;
		pushDir.x = hit.moveDirection.x;
		pushDir.z = hit.moveDirection.z;
		body.velocity = pushDir * force;
		return true;
	}
}
