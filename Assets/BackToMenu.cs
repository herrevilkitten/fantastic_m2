using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class BackToMenu : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Button button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			StateManager.ChangeGameState (StateManager.GameState.Title);
		});

	}
}
