using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour {
	public float myTimer;
	public GameObject player = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myTimer -= Time.deltaTime;
		if (myTimer > 0) {
			Text timerTextBox = GameObject.Find ("TimerTextbox").GetComponent<Text> ();
			timerTextBox.text = "Remaining Time=" + (int)myTimer;
		} else {
			Ragdoll doll =  player.GetComponent<Ragdoll> ();
			doll.SetKinematic(false);
			player.GetComponent<Animator>().enabled=false;
		}
	}
}
