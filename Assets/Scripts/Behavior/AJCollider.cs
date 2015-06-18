using UnityEngine;
using System.Collections;

public class AJCollider : MonoBehaviour {
	
	Animator animator;
	NavMeshAgent nav;
	float runningRange = 5000.0f;
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
			
			float targetDestination = collider.transform.position.x  - (Random.value*runningRange);
			// Use this targetDestination to where you want to move your enemy NavMesh Agent
			nav.enabled = true;
			nav.SetDestination (new Vector3(targetDestination,collider.transform.position.y, collider.transform.position.z)) ;
			animator.SetBool ("IsPlayerNear", true);
			Invoke ("StopAJ", 10f);
		}
	}
	
	void OnTriggerExit(Collider collider) {
		if (collider.tag == "Player") {
			animator.SetBool ("IsPlayerNear", false);
		}
	}
	
	void StopAJ() {
		animator.SetBool ("IsPlayerNear", false);
	}
}
