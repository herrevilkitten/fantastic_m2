using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public string message;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Confess() {
		DialogManager.PopUp (name + ": " + message);
	}

}
