using UnityEngine;
using UnityEngine.UI;
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
	public GameObject buttonPanel;

	// Use this for initialization
	void Start ()
	{
		StateManager.Pause ();
		musicManager.PlayTitleClip ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log ("Title state: " + titleState);
		switch (titleState) {
		case TitleState.SHOW_PRESENTS:
			presents.color = new Color (presents.color.r, presents.color.g, presents.color.b, Mathf.Lerp (presents.color.a, 1.0f, .05f));
			if (presents.color.a >= .9f) {
				titleState = TitleState.HIDE_PRESENTS;
			}
			break;
		case TitleState.HIDE_PRESENTS:
			presents.color = new Color (presents.color.r, presents.color.g, presents.color.b, Mathf.Lerp (presents.color.a, 0f, .05f));
			if (presents.color.a <= .01f) {
				presents.color = new Color (presents.color.r, presents.color.g, presents.color.b, 0f);
				titleState = TitleState.SHOW_PRODUCTION;
			}
			break;
		case TitleState.SHOW_PRODUCTION:
			production.color = new Color (production.color.r, production.color.g, production.color.b, Mathf.Lerp (production.color.a, 1.0f, .05f));
			if (production.color.a >= .9f) {
				titleState = TitleState.HIDE_PRODUCTION;
			}
			break;
		case TitleState.HIDE_PRODUCTION:
			production.color = new Color (production.color.r, production.color.g, production.color.b, Mathf.Lerp (production.color.a, 0f, .05f));
			if (production.color.a <= .01f) {
				production.color = new Color (production.color.r, production.color.g, production.color.b, 0f);
				titleState = TitleState.SHOW_LOGO;
			}
			break;
		case TitleState.SHOW_LOGO:
			logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, Mathf.Lerp (logo.color.a, 1f, .05f));

			Button[] buttons = buttonPanel.transform.GetComponentsInChildren<Button> ();
			foreach (Button button in buttons) {
				ColorBlock colorBlock = button.colors;
				Color color = colorBlock.normalColor;
				colorBlock.normalColor = new Color (color.r, color.g, color.b, Mathf.Lerp (color.a, 1f, .05f));
				button.colors = colorBlock;
			}

			Text[] texts = buttonPanel.transform.GetComponentsInChildren<Text> ();
			foreach (Text text in texts) {
				Color color = text.color;
				text.color = new Color (color.r, color.g, color.b, Mathf.Lerp (color.a, 1f, .05f));
			}
			if (logo.color.a >= .9f) {
				titleState = TitleState.DONE;
			}
			break;
		}
	}
}
