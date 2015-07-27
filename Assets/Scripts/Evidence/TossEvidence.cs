using UnityEngine;
using System.Collections;

public class TossEvidence : UsableAfterTime
{
	override protected bool CanInteract (GameObject actor)
	{
		for (int i = 0; i < actor.transform.childCount; ++i) {
			Transform child = actor.transform.GetChild (i);
			if (child.GetComponent<TossableEvidence> () != null) {
				return true;
			}
		}

		DialogManager.PopUp ("You have nothing to toss.");
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
					Debug.Log ("We can toss " + evidence.gameObject);
					break;
				}
			}

			if (evidence != null) {
				evidence.parent = transform;
				evidence.position = transform.position;
				string flag = evidence.GetComponent<GatherEvidence> ().flag;
				StateManager.SetFlag (flag + "Removed");
				Debug.Log ("Plant that evidence!");
				DialogManager.PopUp ("You have tossed the " + gameObject.name);
			}
		};
	}
}
