using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour
{
	public Canvas dialogSystem;
	Text dialogText;
	float timescale;

	// Use this for initialization
	void Start ()
	{
		timescale = Time.timeScale;
		dialogText = dialogSystem.transform.Find ("DialogText/DialogText").GetComponent<Text> ();
	}

	public void Show ()
	{
		dialogSystem.enabled = true;
		Time.timeScale = 0.0f;
	}

	public void Hide ()
	{
		dialogSystem.enabled = false;
		Time.timeScale = timescale;
	}

	public void SetText (string text)
	{
		dialogText.text = text;
	}

	public void DisableDialogs ()
	{
		SetDialog (0, null, null);
		SetDialog (1, null, null);
		SetDialog (2, null, null);
	}

	public void SetDialog (int index, string text, UnityEngine.Events.UnityAction action)
	{
		GameObject button = dialogSystem.transform.FindChild ("DialogOptions/DialogOption" + index).gameObject;
		if (text == null) {
			button.SetActive (false);
			return;
		}

		button.SetActive (true);
		button.transform.FindChild ("Button").FindChild ("Text").GetComponent<Text> ().text = " " + text;
		button.transform.FindChild ("Button").GetComponent<Button> ().onClick.RemoveAllListeners ();
		button.transform.FindChild ("Button").GetComponent<Button> ().onClick.AddListener (action);
	}
}
