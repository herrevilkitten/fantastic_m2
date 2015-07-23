﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionManager : MonoBehaviour
{
	static InteractionManager instance;

	public delegate void OnInteractionSuccess ();

	float startTime;
	float duration;
	Slider timeBar;
	Text timeLabel;
	OnInteractionSuccess onInteractionSuccess;

	// Use this for initialization
	void Awake ()
	{
		startTime = 0f;
		timeBar = GetComponent<Slider> ();
		timeLabel = GetComponentInChildren<Text> ();
		InteractionManager.instance = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!Input.GetButton ("Use") && startTime != 0f) {
			Debug.Log ("Cancelling action");
			startTime = 0f;
		}

		if (startTime == 0f) {
			timeBar.value = 0f;
			timeLabel.text = "";
		} else {
			timeBar.value = Mathf.Min (100, (Time.time - startTime) / duration * 100);
			
			if ((startTime + duration) < Time.time) {
				Debug.Log ("Interaction time: " + startTime + " " + duration + " " + Time.time + " " + ((startTime + duration) > Time.time));
				startTime = 0f;
				onInteractionSuccess ();
			}
		}

		foreach (Image image in timeBar.GetComponentsInChildren<Image>()) {
			image.enabled = (startTime != 0f);
		}
	}

	public static void StartInteraction (float duration, OnInteractionSuccess onInteractionSuccess, string label = "")
	{
		InteractionManager.instance.startTime = Time.time;
		InteractionManager.instance.duration = duration;
		InteractionManager.instance.onInteractionSuccess = onInteractionSuccess;
		instance.timeLabel.text = label;
	}
}
