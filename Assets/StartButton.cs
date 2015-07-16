using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class StartButton : MonoBehaviour
{
	Button button;

	public Canvas titleCanvas;
	public MusicManager musicManager;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {

			StateManager.ChangeGameState (StateManager.GameState.Playing);

			musicManager.PlayGameClip ();
		});

		EventTrigger trigger = GetComponent<EventTrigger> ();

		// http://answers.unity3d.com/questions/854251/how-do-you-add-an-ui-eventtrigger-by-script.html
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.Select;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Start button selected");
		});
		trigger.triggers.Add (entry);

		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.Deselect;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Start button deselected");
		});
		trigger.triggers.Add (entry);
	}
}
