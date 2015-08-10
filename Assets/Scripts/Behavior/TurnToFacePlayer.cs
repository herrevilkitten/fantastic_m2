using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnToFacePlayer : MonoBehaviour
{
	Transform camera;
	
	// Use this for initialization
	void Start ()
	{
		camera = GameObject.FindWithTag ("MainCamera").transform;
	}

	void Update ()
	{
		Vector3 target = new Vector3 (camera.position.x, transform.position.y, camera.position.z);
		transform.LookAt (2 * transform.position - target);
	}
}
