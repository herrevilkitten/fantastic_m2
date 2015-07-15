using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public Image crosshairs;

	// Update is called once per frame
	void Update ()
	{
		switch (StateManager.currentState) {
		case StateManager.GameState.Playing:
			if (Input.GetButtonDown ("Toggle Camera")) {
				StateManager.ToggleCamera ();
			}

			if (Input.GetKeyDown (KeyCode.J)) {
				StateManager.ChangeGameState (StateManager.GameState.Journal);
			}
			break;

		case StateManager.GameState.Journal:
			if (Input.GetButtonDown ("Cancel") || Input.GetKeyDown (KeyCode.J)) {
				StateManager.ChangeGameState (StateManager.GameState.Playing);
			}
			break;
		}
	}
}
