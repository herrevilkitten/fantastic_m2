using UnityEngine;
using System.Collections;

public class CameraFlyby : MonoBehaviour
{
	bool paused;
	Transform[] locations;
	int currentLocation;

	public Camera camera;


	// Use this for initialization
	void Start ()
	{
		locations = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; ++i) {
			locations [i] = transform.GetChild (i);
		}
		currentLocation = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void Play ()
	{
		paused = false;
	}

	public void Pause ()
	{
		paused = true;
	}
}
