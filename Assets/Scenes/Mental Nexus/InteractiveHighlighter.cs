using UnityEngine;
using System.Collections;

public class InteractiveHighlighter : MonoBehaviour
{
	const string HIGHLIGHTER_NAME = "Interactive Hightlight";

	public ParticleSystem particles;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton ("Use")) {
			Camera playerCamera = transform.parent.FindChild ("FollowCamera").gameObject.GetComponent<Camera> ();
			// http://answers.unity3d.com/questions/229778/how-to-find-out-which-object-is-under-a-specific-p.html
			Ray ray = playerCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				//    Debug.DrawLine (ray.origin, hit.point);
				var objectHit = hit.collider.gameObject;
				InteractiveObject interaction = objectHit.GetComponent<InteractiveObject> ();
				if (interaction != null && objectHit.transform.FindChild (HIGHLIGHTER_NAME)) {
					Debug.Log ("Interacting with " + objectHit);
					interaction.Interact (gameObject);
				}
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		InteractiveObject interaction = other.gameObject.GetComponent<InteractiveObject> ();
		if (interaction != null) {
			if (particles != null) {
				ParticleSystem instance = (ParticleSystem)Instantiate (particles, other.transform.position, Quaternion.LookRotation (other.transform.up, other.transform.forward));
				instance.name = HIGHLIGHTER_NAME;
				instance.playOnAwake = true;
				instance.loop = true;
				instance.Play ();
				instance.transform.SetParent (other.gameObject.transform);
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		InteractiveObject interaction = other.gameObject.GetComponent<InteractiveObject> ();
		if (interaction != null) {
			Transform t = other.gameObject.transform.FindChild (HIGHLIGHTER_NAME);
			if (t != null) {
				Destroy (t.gameObject);
			}
		}
	}
}
