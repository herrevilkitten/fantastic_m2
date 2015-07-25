using UnityEngine;
using System.Collections;

public class WipeEvidence : UsableAfterTime
{
	public string flag;

	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			Debug.Log ("Wipe that evidence: " + flag);
			StateManager.SetFlag (flag + "Removed");
			Destroy (gameObject);
		};
	}
}
