using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour
{
	Button button;

	public Canvas titleCanvas;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			titleCanvas.enabled = false;
			StateManager.Play ();
		});
	}
}
