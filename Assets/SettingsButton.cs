using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SettingsButton : MonoBehaviour
{
	public Slider musicVolume;
	public Toggle musicMute;
	public Slider sfxVolume;
	public Toggle sfxMute;

	public Toggle showInteractive;
	public Slider difficulty;
	public Text difficultyTitle;

	// Use this for initialization
	void Start ()
	{
		Button button = GetComponent<Button> ();
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
	}
}
