using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SuspicionImageUpdate : MonoBehaviour
{
	public Sprite noSuspicionSprite;
	public Sprite suspicionSprite;
	Image suspicionImage;

	// Use this for initialization
	void Awake ()
	{
		suspicionImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float scaling = Mathf.Min (1f + ((float)StateManager.detectionCount) / 5, 5f);
		Vector3 scalingVector = new Vector3 (scaling, scaling, scaling);
		suspicionImage.rectTransform.localScale = scalingVector;

		if (StateManager.detectionCount == 0) {
			suspicionImage.sprite = noSuspicionSprite;
		} else {
			suspicionImage.sprite = suspicionSprite;
		}

		if (StateManager.suspicionLevel == 0) {
			if (StateManager.detectionCount == 0) {
				suspicionImage.color = new Color (.5f, .5f, .5f);
			} else {
				suspicionImage.color = new Color (1f, 1f, 1f);
			}
		} else if (StateManager.suspicionLevel <= 12) {
			suspicionImage.color = new Color (0f, 1f, 0f);
		} else if (StateManager.suspicionLevel <= 25) {
			suspicionImage.color = new Color (0f, 0f, 1f);
		} else if (StateManager.suspicionLevel <= 37) {
			suspicionImage.color = new Color (1f, 1f, 0f);
		} else if (StateManager.suspicionLevel < 50) {
			suspicionImage.color = new Color (1f, .5f, 0f);
		} else {
			suspicionImage.color = new Color (1f, 0f, 0f);
		}
	}
}
