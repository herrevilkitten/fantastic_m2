using UnityEngine;
using RAIN.Action;
using RAIN.Core;
using RAIN.Entities;
using RAIN.Entities.Aspects;
using RAIN.Perception.Sensors;
using System.Collections;
using System.Collections.Generic;

[RAINAction]
public class StationaryCopDetectPlayer : RAINAction
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
		if (StateManager.CompletedEvidence ()) {
			ai.WorkingMemory.SetItem("currentAction", "stop");
			return ActionResult.SUCCESS;
		}
		
		
		IList<RAINAspect> redBalls = ai.Senses.Sense ("VisualSensor", "RedBall", RAINSensor.MatchType.ALL);
		
		if (redBalls.Count > 0) {
			//Debug.Log (ai.Body.name + ": There are red balls");
			foreach (RAINAspect aspect in redBalls) {
				BallBehavior behavior = aspect.MountPoint.GetComponent<BallBehavior>();
				if (currentTime-behavior.GetThrownTime() < 2.5f) {
					//deliberate here. last ball overrides previous ball distraction
					Debug.Log (ai.Body.name + ": Ball position" + aspect.MountPoint.position);
					ai.WorkingMemory.SetItem<Transform>("LastBallDetect", aspect.MountPoint);
					ai.WorkingMemory.SetItem<string>("currentAction", "distracted");
					return ActionResult.SUCCESS;
				}
			}
		}
		
		if (currentAction.Equals ("distracted")) {
			Transform ball = ai.WorkingMemory.GetItem<Transform>("LastBallDetect");
			if (ball!=null) {
				BallBehavior behavior = ball.GetComponent<BallBehavior>();
				if (currentTime - behavior.GetThrownTime() < 10.0f) {
					ai.WorkingMemory.SetItem<string>("currentAction", "distracted");
					return ActionResult.SUCCESS;
				}
			}
		}
		
		
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
						//StateManager.AddDetection(ai.Body.name);
						radio.RadioAddDetection(ai);
						
						if (currentAction.Equals("arrest")) {
							return Arrest (ai);
						} 
						
						float lastObservedTime = ai.WorkingMemory.GetItem <float> ("FirstObservedTime");
						Vector3 lastDetectedPosition = ai.WorkingMemory.GetItem <Vector3> ("LastDetectedPosition");
						
						if (!currentAction.Equals("observe")) {
							ai.WorkingMemory.SetItem("currentAction", "observe");
							ai.WorkingMemory.SetItem("FirstObservedTime", currentTime);
							ai.WorkingMemory.SetItem("LastDetectedPosition", aspect.MountPoint.position);
							break;
						}
						
						//currently observing the player
						if (currentAction.Equals ("observe")) {
							if (InteractionManager.IsPlayerInteractingWithObject()) {
								//Debug.Log (ai.Body.name + "i'm observing and he looks suspicius. let's check with dispatcher if i should radio him in");
								//call in suspicious behavior and see what dispatcher tells me to do based on current suspicion score
								string nextAction = radio.RadioDispatcher(ai, aspect.MountPoint, currentTime);
								ai.WorkingMemory.SetItem("currentAction", nextAction);
								break;
							}
						}
						
						
						
					}
				}
				//I do not see the player. Keep patrolling
			} else {
				
				if (currentAction.Equals("arrest")) {
					return Arrest (ai);
				}
				
				//Debug.Log (ai.Body.name + "No player, patrol");
				Patrol (ai);
				
				//StateManager.ReduceDetection(ai.Body.name);
				radio.RadioReduceDetection(ai);
				
			}
		}
		return ActionResult.SUCCESS;
	}
	
	private ActionResult Arrest (AI ai)
	{
		Debug.Log (ai.Body.name + "continue arresting");
		if (IsPlayerCloseToNPC (ai, 1.0f)) {
			Debug.Log ("Trigger Arrest Sequence");
			ai.WorkingMemory.SetItem ("trigArrestSequence", true);
		}
		return ActionResult.SUCCESS;
	}
	
	public void Patrol(AI ai) {
		//		Debug.Log ("just patrolling");
		ai.WorkingMemory.SetItem("currentAction", "patrol");
		ai.WorkingMemory.SetItem<float>("FirstObservedTime", 0.0f);
		ai.WorkingMemory.SetItem("PlayerPosition", new Vector3());
		
	}
	
	public bool ShouldLookForPlayer(AI ai, float currentTime) {
		
		float lastDetectCycle = ai.WorkingMemory.GetItem<float> ("LastDetectCycle");
		
		return (lastDetectCycle == 0.0f) || ((lastDetectCycle != 0) && (currentTime - lastDetectCycle) >= 0.3f);
	}
	
	public bool IsPlayerCloseToNPC(RAIN.Core.AI ai, double range) {
		Vector3 playerPosition = GetCurrentPosition (ai);
		Vector3 npcPosition = ai.Body.transform.position;
		
		return AreTwoVectorsCloseEnough (playerPosition, npcPosition, range);
	}
	
	private bool AreTwoVectorsCloseEnough(Vector3 vec1, Vector3 vec2, double range=0.25f) {
		Vector3 difference = vec1 - vec2;
		
		bool xNear = ((-1)*range) <= difference.x && difference.x <= range;
		bool zNear = ((-1)*range) <= difference.z && difference.z <= range;
		
		return xNear && zNear;
	}
	
	public Vector3 GetCurrentPosition(AI ai) {
		return ai.WorkingMemory.GetItem <Vector3> ("PlayerPosition");
	}
}