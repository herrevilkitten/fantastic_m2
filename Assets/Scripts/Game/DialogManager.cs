using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour
{
	static Canvas dialogCanvas;
	static Text dialogText;

	static DialogManager ()
	{
		dialogCanvas = GameObject.Find ("DialogCanvas").GetComponent<Canvas> ();
	}

	public static void Show ()
	{
		if (!dialogCanvas.enabled) {
			StateManager.Pause ();
			dialogCanvas.enabled = true;
			dialogText = dialogCanvas.transform.Find ("DialogText/DialogText").GetComponent<Text> ();
			dialogText.color = new Color (1f, 1f, 1f, 1f);
		}
	}

	public static void Hide ()
	{
		if (dialogCanvas.enabled) {
			StateManager.Play ();
			dialogCanvas.enabled = false;
		}
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

	public static void PopUp (string text)
	{
		GameObject popupHandler = GameObject.Find ("PopupHandler");
		PopupManager popupManager = popupHandler.GetComponent<PopupManager> ();
		popupManager.PopUp (text);
	}

	public static void Floating (GameObject target, string text, float duration = 2f, float height = 2f)
	{
		GameObject overheadText = MonoBehaviour.Instantiate (Resources.Load ("OverheadText") as GameObject);
		overheadText.GetComponent<TextMesh> ().text = text;
		overheadText.GetComponent<FadeAway> ().duration = duration;
		overheadText.GetComponent<StayWithObject> ().target = target;
		overheadText.GetComponent<StayWithObject> ().offset = Vector3.up * height;
	}
}
