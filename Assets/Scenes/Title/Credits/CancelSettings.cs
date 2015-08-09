using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CancelSettings : MonoBehaviour
{
	public GameObject logoPanel;
	public GameObject settingsPanel;
	public MusicManager musicManager;
	public SfxManager sfxManager;

	// Use this for initialization
	void Start ()
	{
		Button button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			// Revert sounds settings
			musicManager.SetMusicVolume (PlayerPrefs.GetFloat ("MusicVolume"));
			musicManager.SetMute (PlayerPrefs.GetInt ("MusicMuted") != 0 ? true : false);
			
			sfxManager.SetSfxVolume (PlayerPrefs.GetFloat ("SfxVolume"));
			sfxManager.SetMute (PlayerPrefs.GetInt ("SfxMuted") != 0 ? true : false);

			QualitySettings.SetQualityLevel (PlayerPrefs.GetInt ("Quality"));
		});
	}
}
