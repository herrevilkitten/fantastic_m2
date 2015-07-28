using UnityEngine;
using System.Collections;

public class WinningScript : MonoBehaviour {

	public float myTimer;
	public GameObject gameOverCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (StateManager.CompletedEvidence ()) {
			myTimer -= Time.deltaTime;

			if (myTimer > 0) {
				Animator anim = GetComponent<Animator>();
				anim.SetBool("IsWinning", true);
			} else if (myTimer < -0.5f && myTimer > -8.0f) {
				StateManager.TurnOnGameOverPanel ();
			} else if (myTimer <= -8.0f) {
				StateManager.TurnOffGameOverPanel ();
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
