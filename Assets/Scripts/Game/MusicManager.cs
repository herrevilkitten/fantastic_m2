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

	public void PlayTitleClip ()
	{
		audioSource.clip = titleClip;
		audioSource.Play ();
	}

	public void PlayGameClip ()
	{
		audioSource.clip = gameClip;
		audioSource.Play ();
	}
	
	public void PlayCreditsClip ()
	{
		audioSource.clip = creditsClip;
		audioSource.Play ();
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
