using UnityEngine;
using System.Collections;

public class PlayerFlashback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log (hit.collider.tag);
		Debug.Log ("I've collided with something");
		if (hit.collider.tag == "Flashback") {
			SetKinematic (false);
			GetComponent<Animator> ().enabled = false;
		}
	}

	void SetKinematic(bool newValue)
	{
		Rigidbody[] bodies=GetComponentsInChildren<Rigidbody>();
		
		foreach (Rigidbody rigidParts in bodies) {
			rigidParts.isKinematic=newValue;
		}
	}
}
