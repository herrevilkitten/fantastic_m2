using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CreditsButton : MonoBehaviour
{
	public GameObject selection;
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		Button button = GetComponent<Button> ();

		EventTrigger trigger = GetComponent<EventTrigger> ();
		
		// http://answers.unity3d.com/questions/854251/how-do-you-add-an-ui-eventtrigger-by-script.html
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.UpdateSelected;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Credits button selected");
			selection.SetActive (true);
		});
		trigger.triggers.Add (entry);
		
		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.Deselect;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Credits button deselected");
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
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
