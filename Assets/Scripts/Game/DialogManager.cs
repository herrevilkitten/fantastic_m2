using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour
{
	static Canvas dialogCanvas;
	static Text dialogText;
	static float timescale;

	static DialogManager ()
	{
		dialogCanvas = GameObject.Find ("DialogCanvas").GetComponent<Canvas> ();
	}

	public static void Show ()
	{
		dialogCanvas.enabled = true;
		timescale = Time.timeScale;
		Time.timeScale = 0.0f;
	}

	public static void Hide ()
	{
		dialogCanvas.enabled = false;
		Time.timeScale = timescale;
	}

	public static bool IsShown ()
	{
		return dialogCanvas != null && dialogCanvas.enabled;
	}

	public static void SetText (string text)
	{
		dialogText = dialogCanvas.transform.Find ("DialogText/DialogText").GetComponent<Text> ();
		dialogText.text = text;
	}

	public static void DisableDialogs ()
	{
		SetDialog (0, null, null);
		SetDialog (1, null, null);
		SetDialog (2, null, null);
	}

	public static void SetDialog (int index, string text, UnityEngine.Events.UnityAction action)
	{
		GameObject button = dialogCanvas.transform.FindChild ("DialogOptions/DialogOption" + index).gameObject;
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
