using UnityEngine;
using System.Collections;

public class PlayerDoorCollision : MonoBehaviour
{
	Rigidbody rigidBody;
	Light light;

	int intensity;
	int target;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		light = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		light.intensity = Mathf.Lerp (light.intensity, target, Time.deltaTime);
		light.bounceIntensity = Mathf.Lerp (light.bounceIntensity, target, Time.deltaTime);
		if (light.intensity < 1) {
			light.enabled = false;
		} else {
			light.enabled = true;
		}
		Debug.Log ("Intensity: " + light.intensity + "/" + light.bounceIntensity);
	}
	
	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("OnTriggerEnter: " + transform.gameObject);
		target = 8;
	}

	void OnTriggerExit (Collider other)
	{
		Debug.Log ("OnTriggerExit: " + transform.gameObject);
		target = 0;
	}
}
