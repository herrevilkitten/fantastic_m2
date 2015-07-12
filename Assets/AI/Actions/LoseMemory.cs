using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class LoseMemory : RAINAction
{
	public override void Start (RAIN.Core.AI ai)
	{
		base.Start (ai);
	}

	private void actOnDetection (RAIN.Core.AI ai, string item, string message)
	{
		float spottedPlayerTime = ai.WorkingMemory.GetItem<float> (item + "Time");
		float currentTime = Time.time;

		Debug.Log ("Looking at " + item + " " + spottedPlayerTime);
		// Have we spotted player?
		if (ai.WorkingMemory.GetItem (item) != null) {
			Debug.Log ("We have spotted " + item + " " + spottedPlayerTime);
			ai.WorkingMemory.SetItem<bool> ("spottedAnything", true);
			
			if (spottedPlayerTime == 0f) {
				ai.WorkingMemory.SetItem<float> (item + "Time", currentTime);
				if (message != null) {
					DialogManager.Floating (ai.Body, message);
				}
			} else {
				ai.WorkingMemory.SetItem<GameObject> (item, null);
			}
		}

	}

	public override ActionResult Execute (RAIN.Core.AI ai)
	{
		actOnDetection (ai, "spottedPlayer", "Hello, sailor.");
		actOnDetection (ai, "spottedAj", "What a cute kid.");
		actOnDetection (ai, "spottedCat", "<i>Achooo</i> Aiiee! A cat!");
		actOnDetection (ai, "spottedMysteryGirl", "How mysterious...");
		actOnDetection (ai, "spottedFountain", "A lovely fountain on a cold day.");

		return ActionResult.SUCCESS;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}