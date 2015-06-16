using UnityEngine;
using System.Collections;

public class PlayerDoorCollision : MonoBehaviour
{
	Rigidbody rigidBody;
	Light teleporterLight;
	AudioSource teleporterSound;
	public int destination;

	int target = 0;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();

		teleporterLight = GetComponent<Light> ();
		teleporterLight.intensity = 0;

		teleporterSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		teleporterLight.intensity = Mathf.Lerp (teleporterLight.intensity, target, Time.deltaTime);
		teleporterLight.bounceIntensity = Mathf.Lerp (teleporterLight.bounceIntensity, target, Time.deltaTime);
		teleporterSound.volume = Mathf.Lerp (teleporterSound.volume, target / 8f, Time.deltaTime);
		if (teleporterLight.intensity < 1) {
			teleporterLight.enabled = false;
			teleporterSound.Stop ();
		} else if (target > 0 && teleporterLight.intensity > 6.5 && destination != null) {
			Application.LoadLevel (destination);
		} else {
			teleporterLight.enabled = true;
			if (!teleporterSound.isPlaying) {
				teleporterSound.Play ();
			}
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			target = 8;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			target = 0;
		}
	}
}
