using UnityEngine;
using System.Collections;

public class PlayerGlassPushHandler : MonoBehaviour, CharacterCollisionHandler
{
	public AudioClip glassCubeAudio;

	AudioSource audioSource;
	public ParticleSystem particles;

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

		if (particles != null) {
			ParticleSystem instance = (ParticleSystem)Instantiate (particles, hit.point, body.rotation);
			instance.Play ();
			Destroy (instance, 1f);
		}

		// Add a little upward "oomf" like you're kicking it
		Vector3 pushDir = Vector3.up * .1f * force;
		if (hit.moveDirection.y < 0f) {
			pushDir = Vector3.zero;
			pushDir.y = hit.moveDirection.y;
		}
		pushDir.x = hit.moveDirection.x;
		pushDir.z = hit.moveDirection.z;
		body.AddForce (pushDir * force);
		return true;
	}
}
