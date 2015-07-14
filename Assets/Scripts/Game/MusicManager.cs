using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	public AudioClip titleClip;
	public AudioClip gameClip;
	public AudioClip creditsClip;

	AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayClip (AudioClip clip)
	{
		if (audioSource.isPlaying) {
			audioSource.Stop ();
		}
		audioSource.clip = clip;
		audioSource.Play ();

	}

	public void PlayTitleClip ()
	{
		PlayClip (titleClip);
	}

	public void PlayGameClip ()
	{
		PlayClip (gameClip);
	}
	
	public void PlayCreditsClip ()
	{
		PlayClip (creditsClip);
	}
	
	public void SetMusicVolume (float volume)
	{
		audioSource.volume = volume;
	}

	public float GetMusicVolume ()
	{
		return audioSource.volume;
	}

	public void ToggleMusic ()
	{
		audioSource.mute = !audioSource.mute;
	}
}
