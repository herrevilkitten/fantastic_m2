using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	public AudioClip titleClip;
	public AudioClip gameClip;
	public AudioClip creditsClip;

	AudioSource audioSource;

	void Awake ()
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

	public void SetMute (bool SetMute)
	{
		audioSource.mute = SetMute;
	}

	public bool GetMute ()
	{
		return audioSource.mute;
	}

	public void ToggleMusic ()
	{
		audioSource.mute = !audioSource.mute;
	}
}
