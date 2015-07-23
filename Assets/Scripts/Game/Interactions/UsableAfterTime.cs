using UnityEngine;
using System.Collections;

public abstract class UsableAfterTime : UsableObject
{
	public float duration;
	public string label;

	abstract protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ();

	override public void OnInteractContinuous (GameObject actor, bool changed)
	{
		if (!changed) {
			return;
		}

		InteractionManager.StartInteraction (duration, OnInteractionSuccess (), label);
	}
}
