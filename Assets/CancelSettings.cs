using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CancelSettings : MonoBehaviour
{
	public GameObject logoPanel;
	public GameObject settingsPanel;
	public MusicManager musicManager;
	public SfxManager sfxManager;
	Button button;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			// Revert sounds settings
			musicManager.SetMusicVolume (PlayerPrefs.GetFloat ("MusicVolume"));
			musicManager.SetMute (PlayerPrefs.GetInt ("MusicMuted") != 0 ? true : false);
			
			sfxManager.SetSfxVolume (PlayerPrefs.GetFloat ("SfxVolume"));
			sfxManager.SetMute (PlayerPrefs.GetInt ("SfxMuted") != 0 ? true : false);

			StateManager.ChangeGameState (StateManager.GameState.Title);
		});
	}
}
