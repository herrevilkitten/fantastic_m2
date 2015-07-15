using UnityEngine;
using System.Collections;

public class SfxManager : MonoBehaviour
{
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
	

	public void SetSfxVolume (float volume)
	{
		audioSource.volume = volume;
	}
	
	public float GetSfxVolume ()
	{
		return audioSource.volume;
	}
	
	public void ToggleSfx ()
	{
		audioSource.mute = !audioSource.mute;
	}

	public void SetMute (bool SetMute)
	{
		audioSource.mute = SetMute;
	}
	
	public bool GetMute ()
	{
		return audioSource.mute;
	}
}
