using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ToggleJournalButton : MonoBehaviour
{
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		Button journalButton = GetComponent<Button> ();
		journalButton.onClick.AddListener (() => {
			if (StateManager.instance.IsPlaying ()) {
				StateManager.instance.ChangeGameState (StateManager.GameState.Pda);
			} else {
				StateManager.instance.ChangeGameState (StateManager.GameState.Playing);
			}
			eventSystem.SetSelectedGameObject (null);
		});
	}
}
