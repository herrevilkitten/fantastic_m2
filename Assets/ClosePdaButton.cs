using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClosePdaButton : MonoBehaviour
{
	public GameObject homePanel;
	public GameObject fromPanel;
	public Button[] buttons;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			homePanel.SetActive (true);
			fromPanel.SetActive (false);
			foreach (Button button in buttons) {
				button.GetComponent<Button> ().interactable = true;
			}
		});
	}
}
