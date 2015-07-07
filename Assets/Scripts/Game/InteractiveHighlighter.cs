using UnityEngine;
using System.Collections;

public class InteractiveHighlighter : MonoBehaviour
{
	const string HIGHLIGHTER_NAME = "Interactive Hightlight";

	public ParticleSystem particles;

	bool previousUse = false;
	void Update ()
	{
		Camera playerCamera = transform.parent.FindChild ("FollowCamera").gameObject.GetComponent<Camera> ();
		Vector3 rayTarget = Input.mousePosition;

		bool use = Input.GetButton ("Use");
		bool changed = false;
		if (use != previousUse) {
			changed = true;
		}

		if (StateManager.cameraMode == StateManager.CameraMode.Fixed) {
			rayTarget = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
			Ray ray = playerCamera.ScreenPointToRay (rayTarget);
			RaycastHit hit;
			InteractiveObject interaction = null;
			if (Physics.Raycast (ray, out hit, 100)) {
				interaction = hit.collider.gameObject.GetComponent<InteractiveObject> ();
			}

			if (interaction != null) {
				Debug.Log ("Interactive object is " + interaction);
				interaction.OnMouseEnter ();
			} else {
				CursorManager.CrosshairsCursor ();
			}
		} 

		if (!StateManager.IsPaused () && use) {
			// http://answers.unity3d.com/questions/229778/how-to-find-out-which-object-is-under-a-specific-p.html
			Ray ray = playerCamera.ScreenPointToRay (rayTarget);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				//    Debug.DrawLine (ray.origin, hit.point);
				GameObject objectHit = hit.collider.gameObject;
				InteractiveObject interaction = objectHit.GetComponent<InteractiveObject> ();
				if (interaction != null) {
					if (objectHit.transform.FindChild (HIGHLIGHTER_NAME)) {
						Debug.Log ("Interacting with " + objectHit);
						if (changed && interaction is InteractiveObject.ClickableInteraction) {
							((InteractiveObject.ClickableInteraction)interaction).OnInteractClick (gameObject);
						}
						if (interaction is InteractiveObject.ContinuousInteraction) {
							((InteractiveObject.ContinuousInteraction)interaction).OnInteractContinuous (gameObject, changed);
						}
					} else {
						// Out of range
						DialogManager.PopUp ("You are too far away to use that.");
					}
				}
			}

		}
		previousUse = use;
	}

	void OnTriggerEnter (Collider other)
	{
		InteractiveObject interaction = other.gameObject.GetComponent<InteractiveObject> ();
		if (interaction != null) {
			if (particles != null) {
				ParticleSystem instance = (ParticleSystem)Instantiate (particles, other.transform.position, Quaternion.LookRotation (Vector3.up, Vector3.up));
				instance.transform.Rotate (Vector3.up);
				instance.name = HIGHLIGHTER_NAME;
				instance.playOnAwake = true;
				instance.loop = true;
				instance.Play ();
				instance.GetComponent<ObjectHighlightMover> ().highlightedObject = other.transform;
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
