using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	int currentLevel;
	// Use this for initialization
	void Start ()
	{
		currentLevel = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey ("1")) {
			currentLevel = 0;
			Application.LoadLevel (currentLevel);
		} else if (Input.GetKey ("2")) {
			currentLevel = 1;
			Application.LoadLevel (currentLevel);
		} else if (Input.GetKey ("3")) {
			currentLevel = 2;
			Application.LoadLevel (currentLevel);
		} else if (Input.GetKey ("4")) {
			currentLevel = 3;
			Application.LoadLevel (currentLevel);
		} else if (Input.GetButton ("Cancel")) {
			Application.LoadLevel (currentLevel);
		}
	}
}
