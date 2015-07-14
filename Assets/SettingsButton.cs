using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsButton : MonoBehaviour
{
	public GameObject logoPanel;
	public GameObject settingsPanel;
	Button button;

	// Use this for initialization
	void Start ()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
			logoPanel.SetActive (false);
			settingsPanel.SetActive (true);
		});
	}
}
