using UnityEngine;
using System.Collections;

public class PlayPianoInteraction : ClickableObject
{
	public float maxPlayTime = 30.0f;
	AudioSource audioSource;
	float playStartTime;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		if (audioSource == null) {
			audioSource = GetComponentInParent<AudioSource> ();
		}
	}

	void Update ()
	{
		if (!audioSource.isPlaying) {
			return;
		}
		float currentTime = Time.realtimeSinceStartup;

		if (currentTime < playStartTime + maxPlayTime) {
			return;
		}

		if (currentTime < playStartTime + maxPlayTime + 2f) {
			audioSource.volume = Mathf.Lerp (audioSource.volume, 0f, .05f);
		} else {
			audioSource.Stop ();
		}
	}

	override public void OnInteractClick (GameObject actor)
	{
		playStartTime = Time.realtimeSinceStartup;

		if (audioSource.isPlaying) {
			return;
		}

		audioSource.volume = 1f;
		audioSource.Play ();
	}
}