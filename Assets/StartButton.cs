using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour
{
	Button button;

	public Canvas titleCanvas;
	public MusicManager musicManager;
	public Camera flybyCamera;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			flybyCamera.enabled = false;

			StateManager.ChangeGameState (StateManager.GameState.Playing);

			musicManager.PlayGameClip ();
		});
	}
}
