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
	private RadioElement radio;

	public override void Start(AI ai){

		if (radio == null) {
			radio = ai.GetCustomElement<RadioElement>();
		}

		float currentTime = Time.fixedTime;

		//has it been greater than 1.5f seconds since I last looked for the player
		if (ShouldLookForPlayer(ai, currentTime)) {
			IList<RAINAspect> matches = ai.Senses.Sense("VisualSensor", "PlayerAspect", RAINSensor.MatchType.ALL);
			ai.WorkingMemory.SetItem<float>("LastDetectCycle", currentTime);

			//i see the player
			if (matches.Count > 0) {
				foreach (RAINAspect aspect in matches)
				{
					if (aspect != null) {
						string currentAction = ai.WorkingMemory.GetItem<string>("currentAction");
						// nothing to observe here. move along (i'm not currently arresting the player either)
						if (!InteractionManager.IsPlayerInteractingWithObject() && !currentAction.Equals("arrest")) {
							Patrol (ai);
							break;
						}

						if (InteractionManager.IsPlayerInteractingWithObject()) {
							// hmm... i'm not observing. let me check out what this guy is doing
							if (!currentAction.Equals("observe")) {
								ai.WorkingMemory.SetItem("currentAction", "observe");
								ai.WorkingMemory.SetItem("FirstObservedTime", currentTime);
								ai.WorkingMemory.SetItem("LastDetectedPosition", aspect.MountPoint.position);
								break;
							}

							//currently observing the player
							if (currentAction.Equals ("observe")) {
								//call in suspicious behavior and see what dispatcher tells me to do based on current suspicion score
								string nextAction = radio.RadioDispatcher(ai, aspect.MountPoint, currentTime);
								ai.WorkingMemory.SetItem("currentAction", nextAction);
								break;
							}

							//do not stop the arrest sequence
							if (currentAction.Equals("arrest")) {
								break;
							} 

							Patrol (ai);
						}
					}
				}
				//I do not see the player. Keep patrolling
			} else {
				Patrol (ai);
			}
		}
	}

	public void Patrol(AI ai) {
		ai.WorkingMemory.SetItem("currentAction", "patrol");
		ai.WorkingMemory.SetItem<float>("FirstObservedTime", 0.0f);
		ai.WorkingMemory.SetItem("LastDetectedPosition", new Vector3());
	}

	public bool ShouldLookForPlayer(AI ai, float currentTime) {

		float lastDetectCycle = ai.WorkingMemory.GetItem<float> ("LastDetectCycle");

		return (lastDetectCycle == 0.0f) || ((lastDetectCycle != 0) && (currentTime - lastDetectCycle) >= 1.0f);
	}

}
