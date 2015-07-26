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

	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);

		if (radio == null) {
			radio = ai.GetCustomElement<RadioElement>();
		}
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		float currentTime = Time.fixedTime;
		string currentAction = ai.WorkingMemory.GetItem<string>("currentAction");
		//do not stop the arrest sequence

		//has it been greater than 1.5f seconds since I last looked for the player

		if (ShouldLookForPlayer(ai, currentTime)) {
//			Debug.Log ("Look for player");
			IList<RAINAspect> matches = ai.Senses.Sense("VisualSensor", "PlayerAspect", RAINSensor.MatchType.ALL);
			ai.WorkingMemory.SetItem<float>("LastDetectCycle", currentTime);

			//i see the player
			if (matches.Count > 0) {
//				Debug.Log (ai.Body.name + "Found player");
				foreach (RAINAspect aspect in matches)
				{
					if (aspect != null) {
						ai.WorkingMemory.SetItem ("Player", aspect.MountPoint);
						ai.WorkingMemory.SetItem ("PlayerPosition", aspect.MountPoint.position);

						//add detection
						StateManager.AddDetection(ai.Body.name);

						if (currentAction.Equals("arrest")) {
							Debug.Log (ai.Body.name + "continue arresting");

							if (IsPlayerCloseToNPC (ai, 1.0f)) {
								Debug.Log ("Trigger Arrest Sequence");
								ai.WorkingMemory.SetItem ("trigArrestSequence", true);	
							}

							return ActionResult.SUCCESS;
						} 

						float lastObservedTime = ai.WorkingMemory.GetItem <float> ("FirstObservedTime");

						if (!currentAction.Equals("observe")) {
							Debug.Log (ai.Body.name + "hmm... i'm not observing. let me check out what this guy is doing");
							
							ai.WorkingMemory.SetItem("currentAction", "observe");
							ai.WorkingMemory.SetItem("FirstObservedTime", currentTime);
							ai.WorkingMemory.SetItem("LastDetectedPosition", aspect.MountPoint.position);
							break;
						}
						
						//currently observing the player
						if (currentAction.Equals ("observe")) {
							if (InteractionManager.IsPlayerInteractingWithObject()) {
								Debug.Log (ai.Body.name + "i'm observing and he looks suspicius. let's check with dispatcher if i should radio him in");
								//call in suspicious behavior and see what dispatcher tells me to do based on current suspicion score
								string nextAction = radio.RadioDispatcher(ai, aspect.MountPoint, currentTime);
								ai.WorkingMemory.SetItem("currentAction", nextAction);
								break;
							}

							if (currentTime - lastObservedTime > 25.0f) {
								Debug.Log (ai.Body.name + "Player is not doing anything suspicous after 25 seconds. Move along.");
								Patrol (ai);
								break;
							}
						}
						


					}
				}
				//I do not see the player. Keep patrolling
			} else {

				if (currentAction.Equals("arrest")) {
					Debug.Log (ai.Body.name + "continue arresting");
					
					if (IsPlayerCloseToNPC (ai, 1.5f)) {
						Debug.Log ("Trigger Arrest Sequence");
						ai.WorkingMemory.SetItem ("trigArrestSequence", true);	
					}
					
					return ActionResult.SUCCESS;
				}

//				Debug.Log (ai.Body.name + "No player, patrol");
				Patrol (ai);

				StateManager.ReduceDetection(ai.Body.name);

			}
		}
		return ActionResult.SUCCESS;
	}

	public void Patrol(AI ai) {
//		Debug.Log ("just patrolling");
		ai.WorkingMemory.SetItem("currentAction", "patrol");
		ai.WorkingMemory.SetItem<float>("FirstObservedTime", 0.0f);
		ai.WorkingMemory.SetItem("LastDetectedPosition", new Vector3());
		ai.WorkingMemory.SetItem("PlayerPosition", new Vector3());
	}

	public bool ShouldLookForPlayer(AI ai, float currentTime) {

		float lastDetectCycle = ai.WorkingMemory.GetItem<float> ("LastDetectCycle");

		return (lastDetectCycle == 0.0f) || ((lastDetectCycle != 0) && (currentTime - lastDetectCycle) >= 0.3f);
	}

	public bool IsPlayerCloseToNPC(RAIN.Core.AI ai, double range) {
		Vector3 playerPosition = GetCurrentPosition (ai);
		Vector3 npcPosition = ai.Body.transform.position;
		
		Vector3 difference = playerPosition - npcPosition;
		
		Debug.Log (difference);
		
		bool xNear = ((-1)*range) <= difference.x && difference.x <= range;
		bool zNear = ((-1)*range) <= difference.z && difference.z <= range;
		
		return xNear && zNear;
	}

	public Vector3 GetCurrentPosition(AI ai) {
		return ai.WorkingMemory.GetItem <Vector3> ("PlayerPosition");
	}
}
