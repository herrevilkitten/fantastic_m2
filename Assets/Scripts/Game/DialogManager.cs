﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour
{
	public Text dialogText;
	CanvasGroup dialogGroup;
	static DialogManager instance = null;
	
	void Start ()
	{
		DialogManager.instance = this;
		dialogGroup = GetComponent<CanvasGroup> ();
	}

	public static void Show ()
	{
		if (instance.dialogGroup.alpha == 0f) {
			StateManager.instance.Pause ();
			instance.dialogGroup.alpha = 1f;
		}
	}

	public static void Hide ()
	{
		if (instance.dialogGroup.alpha == 1f) {
			StateManager.instance.Play ();
			instance.dialogGroup.alpha = 0f;
		}
	}

	public static bool IsShown ()
	{
		return instance.dialogGroup != null && instance.dialogGroup.alpha == 1f;
	}

	public static void SetText (string text)
	{
		instance.dialogText.text = text;
	}

	public static void DisableDialogs ()
	{
		SetDialog (0, null, null);
		SetDialog (1, null, null);
		SetDialog (2, null, null);
	}

	public static void SetDialog (int index, string text, UnityEngine.Events.UnityAction action)
	{
		GameObject button = instance.dialogGroup.transform.FindChild ("DialogOptions/DialogOption" + index).gameObject;
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

	public static void Conversation (string person1Text, string person2Text)
	{
		GetConversationPanel ().color = new Color (0f, 0f, 0f, 0.5f);

		Text person1TextBoxText = GetPersonTextBox ("Person1TextBox");
		person1TextBoxText.text = person1Text;
		person1TextBoxText.color = new Color (255f, 255f, 33f, 1f);

		Text person2TextBoxText = GetPersonTextBox ("Person2TextBox");
		person2TextBoxText.text = person2Text;
		person2TextBoxText.color = new Color (255f, 255f, 33f, 1f);
	}

	public static void StopConversation ()
	{
		GetConversationPanel ().color = new Color (0f, 0f, 0f, 0f);

		Text person1TextBoxText = GetPersonTextBox ("Person1TextBox");
		person1TextBoxText.color = new Color (255f, 255f, 33f, 0f);
		
		Text person2TextBoxText = GetPersonTextBox ("Person2TextBox");
		person2TextBoxText.color = new Color (255f, 255f, 33f, 0f);
	}

	public static Text GetPersonTextBox (string name)
	{
		GameObject PersonTextBox = GameObject.Find (name);
		return PersonTextBox.GetComponent<Text> ();
	}

	public static Image GetConversationPanel ()
	{
		return GameObject.Find ("ConversationPanel").GetComponent<Image> ();
	}

}
