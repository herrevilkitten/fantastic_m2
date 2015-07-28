using UnityEngine;
using System.Collections;

public class BurnEvidence : UsableAfterTime
{
	override protected bool CanInteract (GameObject actor)
	{
		for (int i = 0; i < actor.transform.childCount; ++i) {
			Transform child = actor.transform.GetChild (i);
			if (child.GetComponent<BurnableEvidence> () != null) {
				return true;
			}
		}

		DialogManager.PopUp ("You have nothing to burn.");
		return false;
	}

	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			Transform evidence = null;

			for (int i = 0; i < actor.transform.childCount; ++i) {
				Transform child = actor.transform.GetChild (i);
				if (child.GetComponent<BurnableEvidence> () != null) {
					evidence = child;
					break;
				}
			}

			if (evidence != null) {
				evidence.parent = transform;
				evidence.position = transform.position;
				string flag = evidence.GetComponent<GatherEvidence> ().flag;
				StateManager.SetFlag (flag + "Removed");
				DialogManager.PopUp ("You have burned the " + evidence.gameObject.name);
				
				InventoryManager.RemoveItem (evidence.gameObject);
			}
		};
	}
}
