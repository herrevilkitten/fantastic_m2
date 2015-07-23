using UnityEngine;
using System.Collections;

public class PlantEvidence : UsableAfterTime
{
	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return () => {
			Debug.Log ("Plant that evidence!");
		};
	}
}
