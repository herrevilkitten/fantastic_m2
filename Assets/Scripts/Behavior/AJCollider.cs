using UnityEngine;
using System.Collections;

public class AJCollider : MonoBehaviour {
	
	Animator animator;
	NavMeshAgent nav;
	float runningRange = 1000.0f;
	float runningRange2 = 1000.0f;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			
			float targetDestinationX = collider.transform.position.x  + (Random.value*runningRange);
			float targetDestinationZ = collider.transform.position.z  + (Random.value*runningRange2);
			// Use this targetDestination to where you want to move your enemy NavMesh Agent
			nav.enabled = true;
			nav.SetDestination (new Vector3(targetDestinationX, collider.transform.position.y, targetDestinationZ)) ;
			animator.SetBool ("IsPlayerNear", true);
			Invoke ("StopAJ", 25f);
		}
	}
	
	void OnTriggerExit(Collider collider) {
		/*
		if (collider.tag == "Player") {
			animator.SetBool ("IsPlayerNear", false);
		}*/
	}
	
	void StopAJ() {
		animator.SetBool ("IsPlayerNear", false);
	}
}
