using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenPdaButton : MonoBehaviour
{
	public GameObject homePanel;
	public GameObject targetPanel;
	public Button[] buttons;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			homePanel.SetActive (false);
			targetPanel.SetActive (true);
			foreach (Button button in buttons) {
				button.GetComponent<Button> ().interactable = false;
			}
		});
	}
}
