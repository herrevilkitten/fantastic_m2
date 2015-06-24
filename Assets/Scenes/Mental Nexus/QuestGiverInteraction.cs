using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestGiverInteraction : InteractiveObject
{
	public Canvas dialogSystem;
	float timescale;

	// Use this for initialization
	void Start ()
	{
		timescale = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	override public void Interact (GameObject actor)
	{
		Debug.Log ("Interacting with " + transform);
		if (dialogSystem == null) {
			return;
		}

		
		Debug.Log ("Opening " + dialogSystem);
		dialogSystem.enabled = true;

		Time.timeScale = 0.0f;

		Text dialogText = dialogSystem.transform.Find ("DialogText/DialogText").GetComponent<Text> ();
		dialogText.text = "Have you lost something or has something lost you?";

		GameObject button = dialogSystem.transform.FindChild ("DialogOptions/DialogOption3").gameObject;
		button.SetActive (false);

		button = dialogSystem.transform.FindChild ("DialogOptions/DialogOption1").gameObject;
		button.SetActive (true);
		button.transform.FindChild ("Button").FindChild ("Text").GetComponent<Text> ().text = " I lost something.";
		button.transform.FindChild ("Button").GetComponent<Button> ().onClick.AddListener (() => {
			Debug.Log ("You lost something.");
			Time.timeScale = timescale;
			dialogSystem.enabled = false;
		});

		button = dialogSystem.transform.FindChild ("DialogOptions/DialogOption2").gameObject;
		button.SetActive (true);
		button.transform.FindChild ("Button").FindChild ("Text").GetComponent<Text> ().text = " Something lost me.";
		button.transform.FindChild ("Button").GetComponent<Button> ().onClick.AddListener (() => {
			Debug.Log ("Something lost you.");
			Time.timeScale = timescale;
			dialogSystem.enabled = false;
		});
	}
}
