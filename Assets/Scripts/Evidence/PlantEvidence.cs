using UnityEngine;
using System.Collections;

public class PlantEvidence : UsableAfterTime
{
	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			Debug.Log ("Plant that evidence!");
		};
	}
}
