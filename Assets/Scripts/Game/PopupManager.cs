using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupManager : MonoBehaviour
{
	const float maxTime = 2f;
	public Text popupText;
	public Image popupBackground;
	float startTime;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.unscaledTime - startTime < maxTime) {
			return;
		}
		popupText.color = new Color (1f, 1f, 1f, Mathf.Lerp (popupText.color.a, 0f, Time.deltaTime));
		popupBackground.color = new Color (0f, 0f, 0f, Mathf.Lerp (popupBackground.color.a, 0f, Time.deltaTime));
		if (Time.unscaledTime - startTime >= maxTime * 1.5f) {
			popupText.color = new Color (1f, 1f, 1f, 0f);
			popupBackground.color = new Color (0f, 0f, 0f, 0f);
		}
	}

	public void PopUp (string text)
	{
		popupText.text = text;
		popupText.color = new Color (1f, 1f, 1f, 1f);
		popupBackground.color = new Color (0f, 0f, 0f, .25f);
		startTime = Time.unscaledTime;
	}
}
