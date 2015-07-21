using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RestartApplicationButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			Application.LoadLevel (Application.loadedLevel);
		});
	}
}
