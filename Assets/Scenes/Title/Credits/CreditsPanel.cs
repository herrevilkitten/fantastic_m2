using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class CreditsPanel : MonoBehaviour
{
	enum CreditsState
	{
		Start,
		FadeIn,
		Show,
		FadeOut
	}

	TextAsset creditsAsset;
	JSONArray creditsJson;
	public Text title;
	public Text credits;
	public Scrollbar scrollbar;
	CreditsState state;
	int frame;
	float frameShowTime;
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Loading credits file");
		creditsAsset = Resources.Load ("Credits") as TextAsset;
		creditsJson = JSON.Parse (creditsAsset.text) as JSONArray;

		Invoke ("ShowCredits", 2f);
	}

	void ShowCredits ()
	{
		state = CreditsState.Start;
		frame = 0;
	}

	void Update ()
	{
		JSONNode currentNode = creditsJson [frame];

		Debug.Log ("Value: " + scrollbar.value + " / " + scrollbar.size + " / " + frame);
		switch (state) {
		case CreditsState.Start:
			string currentTitle = currentNode ["title"].Value;
			string currentText = currentNode ["text"].Value;

			title.color = new Color (1f, 1f, 1f, 0f);
			credits.color = new Color (1f, 1f, 1f, 0f);
			title.text = currentTitle;
			credits.text = "\n" + currentText + "\n";

			state = CreditsState.FadeIn;
			break;

		case CreditsState.FadeIn:
			scrollbar.value = 1f;
			title.color = new Color (1f, 1f, 1f, Mathf.Lerp (title.color.a, 1f, .15f));
			credits.color = new Color (1f, 1f, 1f, Mathf.Lerp (credits.color.a, 1f, .15f));

			if (title.color.a > .9f) {
				title.color = new Color (1f, 1f, 1f, 1f);
				credits.color = new Color (1f, 1f, 1f, 1f);
				state = CreditsState.Show;
				frameShowTime = Time.realtimeSinceStartup;
			}
			break;
		case CreditsState.Show:
			if (scrollbar.value > .05f && scrollbar.size < .95f) {
				scrollbar.value = scrollbar.value - scrollbar.size / 10f;
				frameShowTime = Time.realtimeSinceStartup;
			} else {
				if (Time.realtimeSinceStartup > frameShowTime + 4f) {
					state = CreditsState.FadeOut;
				}
			}
			break;
		case CreditsState.FadeOut:
			title.color = new Color (1f, 1f, 1f, Mathf.Lerp (title.color.a, 0, .15f));
			credits.color = new Color (1f, 1f, 1f, Mathf.Lerp (credits.color.a, 0, .15f));
			if (title.color.a < .05f) {
				state = CreditsState.Start;
				frame = frame + 1;
				if (creditsJson [frame] == null) {
					frame = 0;
				}
			}
			break;
		}
	}
}
