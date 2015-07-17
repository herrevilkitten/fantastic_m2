using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SettingsButton : MonoBehaviour
{
	Button button;

	public Slider musicVolume;
	public Toggle musicMute;
	public Slider sfxVolume;
	public Toggle sfxMute;
	public GameObject selection;
	public EventSystem eventSystem;

	public Toggle showInteractive;
	public Slider difficulty;
	public Text difficultyTitle;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			musicVolume.value = PlayerPrefs.GetFloat ("MusicVolume");
			musicMute.isOn = PlayerPrefs.GetInt ("MusicMuted") != 0 ? true : false;
			sfxVolume.value = PlayerPrefs.GetFloat ("SfxVolume");
			sfxMute.isOn = PlayerPrefs.GetInt ("SfxMuted") != 0 ? true : false;

			showInteractive.isOn = PlayerPrefs.GetInt ("ShowInteractive") != 0 ? true : false;
			difficulty.value = PlayerPrefs.GetInt ("Difficulty");

			string text = "Difficulty: ";
			switch ((int)difficulty.value) {
			case 1:
				text += "Easy";
				break;
			case 2:
				text += "Normal";
				break;
			case 3:
				text += "Hard";
				break;
			}
			difficultyTitle.text = text;

			StateManager.ChangeGameState (StateManager.GameState.Settings);
		});

		EventTrigger trigger = GetComponent<EventTrigger> ();
		
		// http://answers.unity3d.com/questions/854251/how-do-you-add-an-ui-eventtrigger-by-script.html
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.UpdateSelected;
		entry.callback.AddListener ((eventData) => {
			Debug.Log ("Settings button selected");
			selection.SetActive (true);
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
			eventSystem.SetSelectedGameObject (button.gameObject);
		});
		trigger.triggers.Add (entry);
	}
}
