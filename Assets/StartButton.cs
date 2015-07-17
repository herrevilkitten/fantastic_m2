﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class StartButton : MonoBehaviour
{
	Button button;

	public Canvas titleCanvas;
	public MusicManager musicManager;
	public GameObject selection;
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			eventSystem.SetSelectedGameObject (null);

			StateManager.ChangeGameState (StateManager.GameState.Playing);

			musicManager.PlayGameClip ();
		});

		EventTrigger trigger = GetComponent<EventTrigger> ();

		// http://answers.unity3d.com/questions/854251/how-do-you-add-an-ui-eventtrigger-by-script.html
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.UpdateSelected;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Start button selected");
			selection.SetActive (true);
		});
		trigger.triggers.Add (entry);

		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.Deselect;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Start button deselected");
			selection.SetActive (false);
		});
		trigger.triggers.Add (entry);
		
		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener ((eventData) => {
			eventSystem.SetSelectedGameObject (button.gameObject);
		});
		trigger.triggers.Add (entry);
	}
}
