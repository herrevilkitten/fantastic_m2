using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	}
	
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
		} else if (Input.GetButton ("Cancel")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
