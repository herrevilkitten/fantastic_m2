using UnityEngine;
using System.Collections;

public abstract class UsableAfterTime : UsableObject
{
	public float duration;
	public string label;

	abstract protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ();

	virtual protected InteractionManager.OnInteractionFailure OnInteractionFailure ()
	{
		return null;
	}

	virtual protected bool CanInteract (GameObject actor)
	{
		return true;
	}

	override public void OnInteractContinuous (GameObject actor, bool changed)
	{
		if (!changed) {
			return;
		}

		if (CanInteract (actor)) {
			InteractionManager.StartInteraction (duration, OnInteractionSuccess (), OnInteractionFailure (), label);
		}
	}
}
