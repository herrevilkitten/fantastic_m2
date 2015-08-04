using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TitleScripting : MonoBehaviour
{
	public MusicManager musicManager;
	public SfxManager sfxManager;

	// Use this for initialization
	void Start ()
	{
		InitializePrefs ();
	}

	void InitializePrefs ()
	{
		if (!PlayerPrefs.HasKey ("initialized")) {
			PlayerPrefs.SetFloat ("MusicVolume", 1f);
			PlayerPrefs.SetInt ("MusicMuted", 0);

			PlayerPrefs.SetFloat ("SfxVolume", 1f);
			PlayerPrefs.SetInt ("SfxMuted", 0);

			PlayerPrefs.SetInt ("ShowInteractive", 1);
			PlayerPrefs.SetInt ("Difficulty", 2);

			PlayerPrefs.SetInt ("initialized", 1);
			PlayerPrefs.SetInt ("Quality", QualitySettings.GetQualityLevel ());
		}

		musicManager.SetMusicVolume (PlayerPrefs.GetFloat ("MusicVolume"));
		musicManager.SetMute (PlayerPrefs.GetInt ("MusicMuted") != 0 ? true : false);

		sfxManager.SetSfxVolume (PlayerPrefs.GetFloat ("SfxVolume"));
		sfxManager.SetMute (PlayerPrefs.GetInt ("SfxMuted") != 0 ? true : false);

		QualitySettings.SetQualityLevel (PlayerPrefs.GetInt ("Quality"));
	}
}
