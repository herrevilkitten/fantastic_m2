using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ButtonHighlight : MonoBehaviour
{
	public GameObject selection;
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		Button button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			selection.SetActive (false);
			eventSystem.SetSelectedGameObject (null);
		});
		EventTrigger trigger = GetComponent<EventTrigger> ();

		// http://answers.unity3d.com/questions/854251/how-do-you-add-an-ui-eventtrigger-by-script.html
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.UpdateSelected;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Settings button selected");
			if (selection != null) {
				selection.SetActive (true);
			}
		});
		trigger.triggers.Add (entry);
		
		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.Deselect;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Settings button deselected");
			selection.SetActive (false);
		});
		trigger.triggers.Add (entry);
		
		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener ((eventData) => {
			eventSystem.SetSelectedGameObject (gameObject);
		});
		trigger.triggers.Add (entry);

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
