using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleJournalButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Button journalButton = GetComponent<Button> ();
		journalButton.onClick.AddListener (() => {
			if (StateManager.currentState == StateManager.GameState.Playing) {
				StateManager.ChangeGameState (StateManager.GameState.Journal);
			} else {
				Debug.Log ("Pressing that button");
				StateManager.ChangeGameState (StateManager.GameState.Playing);
			}
		});
	}
}
