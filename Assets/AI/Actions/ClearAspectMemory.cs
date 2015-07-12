using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class ClearAspectMemory : RAINAction
{
	const float MAXIMUM_MEMORY = 30.0f;
	
	public override void Start (RAIN.Core.AI ai)
	{
		base.Start (ai);
	}

	private void forget (RAIN.Core.AI ai, string item)
	{
		float currentTime = Time.time;
		float maximumMemory = MAXIMUM_MEMORY;

		ai.WorkingMemory.SetItem<GameObject> (item, null);

		if (ai.WorkingMemory.ItemExists (item + "MaximumMemory")) {
			maximumMemory = ai.WorkingMemory.GetItem<float> (item + "MaximumMemory");
		}
		
		float spottedTime = ai.WorkingMemory.GetItem<float> (item + "Time");
		
		if (spottedTime != 0f) {
			if (spottedTime + maximumMemory < currentTime) {
				Debug.Log ("Removing memory");
				ai.WorkingMemory.SetItem<float> (item + "Time", 0f);
			}
		}

	}

	public override ActionResult Execute (RAIN.Core.AI ai)
	{
		forget (ai, "spottedPlayer");
		forget (ai, "spottedAJ");
		forget (ai, "spottedCat");
		forget (ai, "spottedMysteryGirl");
		forget (ai, "spottedFountain");

		ai.WorkingMemory.SetItem<bool> ("spottedAnything", false);

		return ActionResult.SUCCESS;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}