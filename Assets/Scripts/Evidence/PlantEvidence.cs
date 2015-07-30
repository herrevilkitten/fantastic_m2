using UnityEngine;
using System.Collections;

public class PlantEvidence : UsableAfterTime
{
	override protected bool CanInteract (GameObject actor)
	{
		bool canInteract = false;
		for (int i = 0; i < actor.transform.childCount; ++i) {
			Transform child = actor.transform.GetChild (i);
			if (child.GetComponent<PlantableEvidence> () != null) {
				canInteract = true;
			}
		}
		if (!canInteract) {
			DialogManager.PopUp ("You have nothing to plant.");
			return false;
		}
		
		if (transform.GetComponentInChildren<PlantableEvidence> () != null) {
			DialogManager.PopUp ("It's not safe to plant more than one thing in the same location.");
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
				if (child.GetComponent<PlantableEvidence> () != null) {
					evidence = child;
					break;
				}
			}

			if (evidence != null) {
				evidence.parent = transform;
				evidence.position = transform.position;
				string flag = evidence.GetComponent<GatherEvidence> ().flag;
				StateManager.SetFlag (flag + "Removed");
				DialogManager.PopUp ("You have planted the " + gameObject.name);
				
				InventoryManager.RemoveItem (evidence.gameObject);
			}
		};
	}
}
