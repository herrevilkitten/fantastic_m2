using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CreditsButton : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Button button = GetComponent<Button> ();
		button.onClick.AddListener (() => {
		});
	}
}
