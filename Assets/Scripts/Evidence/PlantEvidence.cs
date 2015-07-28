using UnityEngine;
using System.Collections;

public class PlantEvidence : UsableAfterTime
{
	override protected bool CanInteract (GameObject actor)
	{
		for (int i = 0; i < actor.transform.childCount; ++i) {
			Transform child = actor.transform.GetChild (i);
			if (child.GetComponent<PlantableEvidence> () != null) {
				return true;
			}
		}

		DialogManager.PopUp ("You have nothing to plant.");
		return false;
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
			}
		};
	}
}
