using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour {
	public float rotationAmount = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, rotationAmount * Time.deltaTime, 0);
	}
}
