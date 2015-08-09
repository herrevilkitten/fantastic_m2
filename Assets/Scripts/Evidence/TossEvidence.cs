using UnityEngine;
using System.Collections;

public class TossEvidence : UsableAfterTime
{
	override protected bool CanInteract (GameObject actor)
	{
		bool canInteract = false;
		for (int i = 0; i < actor.transform.childCount; ++i) {
			Transform child = actor.transform.GetChild (i);
			if (child.GetComponent<TossableEvidence> () != null) {
				canInteract = true;
			}
		}
		if (!canInteract) {
			DialogManager.PopUp ("You have nothing to toss.");
			return false;
		}

		if (transform.GetComponentInChildren<TossableEvidence> () != null) {
			DialogManager.PopUp ("It's not safe to toss more than one thing in the same location.");
			return false;
		}

		return true;
	}

	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			Transform evidence = null;

			for (int i = 0; i < actor.transform.childCount; ++i) {
				Transform child = actor.transform.GetChild (i);
				if (child.GetComponent<TossableEvidence> () != null) {
					evidence = child;
					break;
				}
			}

			if (evidence != null) {
				evidence.parent = transform;
				evidence.position = transform.position;
				string flag = evidence.GetComponent<GatherEvidence> ().flag;
				StateManager.instance.SetFlag (flag + "Removed");
				DialogManager.PopUp ("You have tossed the " + evidence.gameObject.name);
				
				InventoryManager.RemoveItem (evidence.gameObject);
			}
		};
	}
}
