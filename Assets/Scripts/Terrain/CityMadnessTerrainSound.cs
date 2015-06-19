using UnityEngine;
using System.Collections;
using System;

public class CityMadnessTerrainSound : MonoBehaviour
{
	/*public AudioClip Grass;
	public AudioClip Floor;
	public AudioClip Sand;
	*/
	public AudioClip[] clips;
	
	public CityMadnessPlayerMovement playerMovement;
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
		
		string surfaceTag = "";
		AudioClip footStepAudio = null;
		
		RaycastHit hit;
		
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			surfaceTag = hit.collider.tag;
		}
		
		if (!surfaceTag.Equals ("Untagged")) {
			//Debug.Log("tag present=" + surfaceTag);
			for(int i=0; i<clips.Length; i++) {
				if (clips[i].name.StartsWith(surfaceTag)) {
					footStepAudio = clips[i];
					break;
				}
			}
		} else {
			
			var surfaceIndex = TerrainSurface.GetMainTexture (transform.position);
			
			Debug.Log ("surfaceIndex=" + surfaceIndex);
			if (surfaceIndex < 0 || surfaceIndex >= clips.Length) {
				return;
			}
			
			footStepAudio = clips[surfaceIndex];
		}
		
		audioSource.Stop ();
		audioSource.volume = playerMovement.getCurrentSpeed () * maxVolume;
		audioSource.clip = footStepAudio;
		audioSource.Play ();
	}
	
	private void StopClip ()
	{
		if (audioSource.isPlaying) {
			audioSource.Stop ();
		}
	}
}
