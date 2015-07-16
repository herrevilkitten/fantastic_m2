using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour {
	public float myTimer = 120.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myTimer -= Time.deltaTime;
		Text timerTextBox = GameObject.Find ("TimerTextbox").GetComponent<Text>();
		timerTextBox.text = "Remaining Time=" + (int)myTimer;
	}
}
