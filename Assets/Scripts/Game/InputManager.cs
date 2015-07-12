using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public Image crosshairs;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("1")) {
			Application.LoadLevel (0);
		} else if (Input.GetKey ("2")) {
			Application.LoadLevel (1);
		} else if (Input.GetKey ("3")) {
			Application.LoadLevel (2);
		} else if (Input.GetKey ("4")) {
			Application.LoadLevel (3);
		}

		if (Input.GetKeyDown ("f")) {
			DialogManager.Floating (GameObject.FindWithTag ("Player"), "Oh man");
		}

		if (Input.GetButtonDown ("Cancel")) {
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetButtonDown ("Toggle Camera")) {
			StateManager.ToggleCamera ();
		}
	}
}
