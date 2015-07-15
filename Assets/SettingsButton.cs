using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsButton : MonoBehaviour
{
	Button button;

	public Slider musicVolume;
	public Toggle musicMute;
	public Slider sfxVolume;
	public Toggle sfxMute;

	public Toggle showInteractive;
	public Slider difficulty;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			musicVolume.value = PlayerPrefs.GetFloat ("MusicVolume");
			musicMute.isOn = PlayerPrefs.GetInt ("MusicMuted") != 0 ? true : false;
			sfxVolume.value = PlayerPrefs.GetFloat ("SfxVolume");
			sfxMute.isOn = PlayerPrefs.GetInt ("SfxMuted") != 0 ? true : false;

			showInteractive.isOn = PlayerPrefs.GetInt ("MusicMuted") != 0 ? true : false;
			difficulty.value = PlayerPrefs.GetInt ("Difficulty");

			StateManager.ChangeGameState (StateManager.GameState.Settings);
		});
	}
}
