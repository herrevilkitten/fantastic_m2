using UnityEngine;
using System.Collections;

public class InteractiveHighlighter : MonoBehaviour
{
	const string HIGHLIGHTER_NAME = "Interactive Hightlight";

	public ParticleSystem particles;

	bool previousUse = false;
	void Update ()
	{
		Camera playerCamera = GameObject.Find ("Main Camera").gameObject.GetComponent<Camera> ();
		Vector3 rayTarget = Input.mousePosition;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		bool use = Input.GetButton ("Use");
		bool changed = false;
		if (use != previousUse) {
			changed = true;
		}

		rayTarget = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Ray ray = playerCamera.ScreenPointToRay (rayTarget);
		RaycastHit hit;
		InteractiveObject interaction = null;
		if (Physics.Raycast (ray, out hit, 100)) {
			interaction = hit.collider.gameObject.GetComponent<InteractiveObject> ();
		}

		if (interaction != null) {
			if (interaction.IsHightlighted ()) {
				if (changed && interaction is InteractiveObject.ClickableInteraction) {
					((InteractiveObject.ClickableInteraction)interaction).OnInteractClick (player);
				}
				if (interaction is InteractiveObject.ContinuousInteraction) {
					((InteractiveObject.ContinuousInteraction)interaction).OnInteractContinuous (player, changed);
				}
			} else {
				// Out of range
				DialogManager.PopUp ("You are too far away to use that.");
			}
		} else {
			CursorManager.instance.CrosshairsCursor ();
		}

		previousUse = use;
	}

	void OnTriggerEnter (Collider other)
	{
		InteractiveObject interaction = other.gameObject.GetComponent<InteractiveObject> ();
		if (interaction != null) {
			if (particles != null) {
				interaction.HighlightObject ();
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		InteractiveObject interaction = other.gameObject.GetComponent<InteractiveObject> ();
		if (interaction != null) {
			interaction.UnhighlightObject ();
		}
	}
}
