﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveSettings : MonoBehaviour
{
	public MusicManager musicManager;
	public SfxManager sfxManager;
	public Slider difficultySlider;
	public Toggle showInteractive;

	// Use this for initialization
	void Start ()
	{
		Button button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			// Revert sounds settings
			PlayerPrefs.SetFloat ("MusicVolume", musicManager.GetMusicVolume ());
			PlayerPrefs.SetInt ("MusicMuted", musicManager.GetMute () ? 1 : 0);
			PlayerPrefs.SetFloat ("SfxVolume", sfxManager.GetSfxVolume ());
			PlayerPrefs.SetInt ("SfxMuted", sfxManager.GetMute () ? 1 : 0);

			PlayerPrefs.SetInt ("Difficulty", (int)difficultySlider.value);
			PlayerPrefs.SetInt ("ShowInteractive", showInteractive.isOn ? 1 : 0);
			PlayerPrefs.SetInt ("Quality", QualitySettings.GetQualityLevel ());
		});

	}
}
