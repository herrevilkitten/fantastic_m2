using UnityEngine;
using System.Collections;

public class PlayerThrowBall : MonoBehaviour {

	bool isWaving = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("t")) {
			isWaving = !isWaving;
			Animator animator = GetComponent<Animator>();
			animator.SetBool("IsWaving", isWaving);
			/*
			if (isWaving) {
				animator.SetLayerWeight(1, 1f);	
			} else {
				animator.SetLayerWeight(1, 0f);	
			}
*/

		}

	}
}
