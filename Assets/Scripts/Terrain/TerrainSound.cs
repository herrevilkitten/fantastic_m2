using UnityEngine;
using System.Collections;
using System;

public class TerrainSound : MonoBehaviour {
	public AudioClip grassSteppingClip;
	public AudioClip stoneSteppingClip;
	public AudioClip sandSteppingClip;

	public PlayerMovement playerMovement;
	public float maxVolume = 0.25f;
	
	AudioClip[] surfaceAudioMap;
	AudioSource audioSource;


	void Start() {
		audioSource = GetComponent<AudioSource> ();

		surfaceAudioMap = new AudioClip[6]{
			grassSteppingClip, //Grass
			stoneSteppingClip, //SandStone
			sandSteppingClip, //Sand
			grassSteppingClip, //DirtGrass
			stoneSteppingClip, //Rock
			grassSteppingClip //Pebble
		};
	}


	void OnStep(string foot) {
		var surfaceIndex = TerrainSurface.GetMainTexture(transform.position);
		
		audioSource.Stop ();
		audioSource.volume = playerMovement.getCurrentSpeed () * maxVolume;
		audioSource.clip = surfaceAudioMap [surfaceIndex];
		audioSource.Play ();
	}

	private void StopClip() {
		if (audioSource.isPlaying) {
			audioSource.Stop ();
		}
	}
}
