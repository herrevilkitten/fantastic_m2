	using UnityEngine;
using System.Collections;
using System;

public class PlayerParticles : MonoBehaviour
{
	public ParticleSystem[] splashParticles;

	void Start ()
	{
	}
	
	void OnStep (string foot)
	{
		string surfaceTag = "";
		
		RaycastHit hit;
		
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			surfaceTag = hit.collider.tag;
		}

		if (surfaceTag.Equals ("Water")) {
			if(foot.Equals ("leftFoot")) {
				splashParticles[0].transform.rotation = new Quaternion(0,0,0,0);
				splashParticles[0].Play ();
			}
			else {
				splashParticles[1].transform.rotation = new Quaternion(0,0,0,0);
				splashParticles[1].Play ();
			}

		}

	}
}
