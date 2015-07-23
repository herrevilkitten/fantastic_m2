using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionManager : MonoBehaviour
{
	public Image fill;
	static InteractionManager instance;

	public delegate void OnInteractionSuccess ();

	public delegate void OnInteractionFailure ();

	float startTime;
	float duration;
	Slider timeBar;
	Text timeLabel;
	OnInteractionSuccess onInteractionSuccess;
	OnInteractionFailure onInteractionFailure;

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
			startTime = 0f;
			if (onInteractionFailure != null) {
				onInteractionFailure ();
			}
		}

		if (startTime == 0f) {
			timeBar.value = 0f;
			timeLabel.text = "";
		} else {
			timeBar.value = Mathf.Min (100, (Time.time - startTime) / duration * 100);
			float color = timeBar.value / 100f;
			fill.color = new Color (1f - color, color, 0f);
			Debug.Log ("fill color " + fill.color);
			
			if ((startTime + duration) < Time.time) {
				startTime = 0f;
				if (onInteractionSuccess != null) {
					onInteractionSuccess ();
				}
			}
		}

		foreach (Image image in timeBar.GetComponentsInChildren<Image>()) {
			image.enabled = (startTime != 0f);
		}
	}

	public static void StartInteraction (float duration, OnInteractionSuccess onInteractionSuccess, 
	                                     OnInteractionFailure onInteractionFailure, string label = "")
	{
		instance.startTime = Time.time;
		instance.duration = duration;
		instance.onInteractionSuccess = onInteractionSuccess;
		instance.onInteractionFailure = onInteractionFailure;
		instance.timeLabel.text = label;
	}
}
