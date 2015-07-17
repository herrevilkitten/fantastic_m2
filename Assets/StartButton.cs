using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class StartButton : MonoBehaviour
{
	Button button;

	public Canvas titleCanvas;
	public MusicManager musicManager;
	public GameObject selection;
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			StateManager.ChangeGameState (StateManager.GameState.Playing);

			musicManager.PlayGameClip ();
		});
	}
}
