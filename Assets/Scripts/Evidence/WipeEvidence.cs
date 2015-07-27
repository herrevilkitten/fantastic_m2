using UnityEngine;
using System.Collections;

public class WipeEvidence : UsableEvidence
{
	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			Debug.Log ("Wipe that evidence: " + flag);
			StateManager.SetFlag (flag + "Removed");
			Destroy (gameObject);
		};
	}
}
