﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TitleScripting : MonoBehaviour
{
	enum TitleState
	{
		SHOW_PRESENTS,
		HIDE_PRESENTS,
		SHOW_PRODUCTION,
		HIDE_PRODUCTION,
		SHOW_LOGO,
		DONE
	}
	;

	TitleState titleState = TitleState.SHOW_PRESENTS;

	public Image logo;
	public Text presents;
	public Text production;
	public MusicManager musicManager;
	public SfxManager sfxManager;
	public GameObject buttonPanel;
	public Button startButton;
	public EventSystem eventSystem;

	RawImage backgroundMovieImage;
	MovieTexture backgroundMovie;
	float movieStartTime;

	void Awake ()
	{
		backgroundMovieImage = GetComponent<RawImage> ();
		backgroundMovie = (MovieTexture)backgroundMovieImage.mainTexture;
	}

	// Use this for initialization
	void Start ()
	{
		InitializePrefs ();

		backgroundMovie.Play ();
		movieStartTime = Time.time;
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
	
	// Update is called once per frame
	void Update ()
	{
		if (titleState != TitleState.DONE) {
			Debug.Log ("Time: " + Time.time + " " + (movieStartTime + backgroundMovie.duration));
			if (Input.GetButtonDown ("Cancel") || Time.time >= (movieStartTime + backgroundMovie.duration)) {
				// Skip title sequence.
				presents.color = new Color (presents.color.r, presents.color.g, presents.color.b, 1f);
				production.color = new Color (production.color.r, production.color.g, production.color.b, 0f);
				logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, 1f);
				buttonPanel.SetActive (true);
				Button[] buttons = buttonPanel.transform.GetComponentsInChildren<Button> ();
				foreach (Button button in buttons) {
					ColorBlock colorBlock = button.colors;
					Color color = colorBlock.normalColor;
					colorBlock.normalColor = new Color (color.r, color.g, color.b, 1f);
					button.colors = colorBlock;
				}
			
				Text[] texts = buttonPanel.transform.GetComponentsInChildren<Text> ();
				foreach (Text text in texts) {
					Color color = text.color;
					text.color = new Color (color.r, color.g, color.b, 1f);
				}

				if (startButton != null) {
					eventSystem.SetSelectedGameObject (startButton.gameObject);
					startButton.GetComponent<EventTrigger> ().OnSelect (null);
				}				

				titleState = TitleState.DONE;
				backgroundMovie.Stop ();
			}
		}
	}
}
