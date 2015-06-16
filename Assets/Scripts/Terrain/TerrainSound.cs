using UnityEngine;
using System.Collections;
using System;

public class TerrainSound : MonoBehaviour
{/*
	public AudioClip grassSteppingClip;
	public AudioClip stoneSteppingClip;
	public AudioClip sandSteppingClip;
	public AudioClip pathSteppingClip;
	*/

	public AudioClip[] clips;

	public PlayerMovement playerMovement;
	public float maxVolume = 0.25f;
	
	AudioClip[] surfaceAudioMap;
	AudioSource audioSource;


	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
/*
		surfaceAudioMap = new AudioClip[6]{
			grassSteppingClip, //Grass
			stoneSteppingClip, //SandStone
			sandSteppingClip, //Sand
			grassSteppingClip, //DirtGrass
			stoneSteppingClip, //Rock
			pathSteppingClip //Path
		};
		*/
	}


	void OnStep (string foot)
	{
		if (clips == null || clips.Length == 0) {
			return;
		}
		var surfaceIndex = TerrainSurface.GetMainTexture (transform.position);
		if (surfaceIndex < 0 || surfaceIndex >= clips.Length) {
			return;
		}

		audioSource.Stop ();
		audioSource.volume = playerMovement.getCurrentSpeed () * maxVolume;
		audioSource.clip = clips [surfaceIndex];
		audioSource.Play ();
	}

	private void StopClip ()
	{
		if (audioSource.isPlaying) {
			audioSource.Stop ();
		}
	}
}
