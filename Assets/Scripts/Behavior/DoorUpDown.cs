using UnityEngine;
using System.Collections;

public class DoorUpDown : MonoBehaviour {
	public int openDistance = 5;
	public int closeDistance = 10;

	public bool isDown = true;
	public AudioClip openSound;
	public AudioClip closeSound;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindWithTag("Player");
		float dist = Vector3.Distance(player.transform.position, transform.position);

		if (dist < openDistance && isDown == true){
			GetComponent<Animation>().Play("DoorMoveUp");
			GetComponent<AudioSource>().clip = openSound;
			GetComponent<AudioSource>().Play();
			isDown = false;
		}

		// Closes the door when the player moves away.
		if (dist > closeDistance && isDown == false){
			GetComponent<Animation>().Play("DoorMoveDown");
			GetComponent<AudioSource>().clip = closeSound;
			GetComponent<AudioSource>().Play();
			isDown = true;
		}
	}
}
