using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitApplicationButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			Application.Quit ();
		});
	}
}
