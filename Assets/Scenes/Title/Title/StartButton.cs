using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class StartButton : MonoBehaviour
{
	Button button;

	public Canvas titleCanvas;
	public MusicManager musicManager;
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			Application.LoadLevel ("Yuk City Market");
			musicManager.PlayGameClip ();
		});
	}
}
