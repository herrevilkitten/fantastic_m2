using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
	public float myTimer;
	public GameObject player = null;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		myTimer -= Time.deltaTime;
		if (myTimer > 0) {
			int minutesLeft = (int)myTimer / 60;
			int secondsLeft = (int)myTimer % 60;
			Text timerTextBox = GameObject.Find ("TimerTextbox").GetComponent<Text> ();
			timerTextBox.text = string.Format ("{0:D2}:{1:D2}", minutesLeft, secondsLeft);
		} else {
			Ragdoll doll = player.GetComponent<Ragdoll> ();
			doll.SetKinematic (false);
			player.GetComponent<Animator> ().enabled = false;
		}
	}
}
