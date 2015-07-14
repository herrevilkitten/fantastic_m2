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
		locations = new Transform[transform.childCount - 1];
		int count = 0;
		for (int i = 0; i < transform.childCount; ++i) {
			Transform child = transform.GetChild (i);
			if (child.gameObject.name.Equals ("FlybyCamera")) {
				continue;
			}
			locations [count++] = child;
		}
		currentLocation = 0;

		camera = transform.FindChild ("FlybyCamera").gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (locations.Length == 0) {
			return;
		}

		Transform cameraPosition = camera.transform;

		float distance = Vector3.Distance (cameraPosition.position, locations [currentLocation].position);
		if (distance <= 10f) {
			currentLocation = (currentLocation + 1) % locations.Length;
		}

		cameraPosition.position = Vector3.Lerp (cameraPosition.position, locations [currentLocation].position, .01f);
		cameraPosition.LookAt (Vector3.zero);
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
