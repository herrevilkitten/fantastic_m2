using UnityEngine;
using System.Collections;

public class PlayPianoInteraction : ClickableObject
{
	public float maxPlayTime = 3.0f;
	AudioSource audioSource;
	float playStartTime;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		if (!audioSource.isPlaying) {
			return;
		}

		if ((playStartTime + maxPlayTime + 2f) > Time.time) {
			audioSource.Stop ();
		} else if (playStartTime + maxPlayTime > Time.time) {
			audioSource.volume = Mathf.Lerp (audioSource.volume, 0f, .1f);
		}
	}

	override public void OnInteractClick (GameObject actor)
	{
		playStartTime = Time.time;

		if (audioSource.isPlaying) {
			return;
		}

		audioSource.Play ();
	}
}