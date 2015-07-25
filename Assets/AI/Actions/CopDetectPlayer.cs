using UnityEngine;
using RAIN.Action;
using RAIN.Core;
using RAIN.Entities;
using RAIN.Entities.Aspects;
using RAIN.Perception.Sensors;
using System.Collections;
using System.Collections.Generic;

[RAINAction]
public class CopDetectPlayer : RAINAction
{
	public override void Start(AI ai){

		float currentTime = Time.fixedTime;

		if (ShouldLookForPlayer(ai, currentTime)) {
			IList<RAINAspect> matches = ai.Senses.Sense("VisualSensor", "PlayerAspect", RAINSensor.MatchType.ALL);
			ai.WorkingMemory.SetItem<float>("LastDetectCycle", currentTime);

			foreach (RAINAspect aspect in matches)
			{
				if (aspect != null) {
					
					Debug.Log ("InteractionManager = " + InteractionManager.IsPlayerInteractingWithObject());
					if (InteractionManager.IsPlayerInteractingWithObject()) {
						RadioManager.Singleton.RadioDispatcher(ai, aspect.MountPoint, Time.fixedTime);
						break;
					} else {
						ai.WorkingMemory.SetItem("currentAction", "patrol");
						break;
					}
				}
			}
		}
	}

	public bool ShouldLookForPlayer(AI ai, float currentTime) {

		float lastDetectCycle = ai.WorkingMemory.GetItem<float> ("LastDetectCycle");

		return (lastDetectCycle == 0.0f) || ((lastDetectCycle != 0) && (currentTime - lastDetectCycle) >= 1.5f);
	}

}
