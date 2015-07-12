using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using System;

[RAINAction]
public class DetectPlayerPosition : RAINAction
{
	private const float offset = 0.75f;
	private const float acceptableRange = 1.0f;

	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{

		Debug.Log ("Entering Detect Player Position Logic");
		Debug.Log ("pNew = " + ai.WorkingMemory.GetItem<Vector3> ("pNew"));
		Debug.Log ("pLast = " + ai.WorkingMemory.GetItem<Vector3> ("pLast"));
		Debug.Log ("npcLastPosition = " + ai.WorkingMemory.GetItem<Vector3> ("npcLastPosition"));

		SetHeadoffLocation (ai);
		SetPositionVariables (ai);
		Debug.Log ("Exiting Detect Player Position Logic");
		return ActionResult.SUCCESS;
	}
	
	private void SetHeadoffLocation(RAIN.Core.AI ai) 
	{
//		Debug.Log ("IsPlayerMoving (ai)=" + ObjectInteractionUtilities.IsPlayerMoving (ai));
		bool IsTriggeringSecret = ai.WorkingMemory.GetItem<bool> ("trigSecrAnim");

		if (ObjectInteractionUtilities.IsPlayerMoving (ai)) {
			Vector3 headoffPosition = new Vector3();
			Vector3 currentPlayerPosition = ObjectInteractionUtilities.GetCurrentPosition(ai);
			Vector3 velocity = ObjectInteractionUtilities.GetVelocity(ai);
			float getTimePassed = ObjectInteractionUtilities.GetTimePassed();
			
			headoffPosition.x = currentPlayerPosition.x - offset + (velocity.x * getTimePassed*4);
			headoffPosition.y = currentPlayerPosition.y;
			headoffPosition.z = currentPlayerPosition.z - offset + (velocity.z * getTimePassed*4);

			/*
			Debug.Log ("velocity="+velocity);
			Debug.Log ("Heading off Player at " + headoffPosition);
			*/
			ai.WorkingMemory.SetItem ("headoffPosition", headoffPosition);
			ai.WorkingMemory.SetItem ("objectToFace", headoffPosition);
			ai.WorkingMemory.SetItem("continueChasingPlayer", true && !IsTriggeringSecret);
		} else {
			Vector3 headoffPosition = new Vector3();
			Vector3 currentPlayerPosition = ObjectInteractionUtilities.GetCurrentPosition(ai);
			Vector3 velocity = ObjectInteractionUtilities.GetVelocity(ai);

			headoffPosition.x = currentPlayerPosition.x - offset;
			headoffPosition.y = currentPlayerPosition.y;
			headoffPosition.z = currentPlayerPosition.z - offset;
			ai.WorkingMemory.SetItem ("headoffPosition", headoffPosition);
			ai.WorkingMemory.SetItem ("objectToFace", ai.WorkingMemory.GetItem<GameObject> ("objectBeingChased"));
			if (ObjectInteractionUtilities.IsPlayerCloseToNPC(ai, acceptableRange)) 
			{
				ai.WorkingMemory.SetItem("continueChasingPlayer", false);
			}
			else 
			{
				ai.WorkingMemory.SetItem("continueChasingPlayer", true && !IsTriggeringSecret);
			}
		}
	}


	private void SetPositionVariables(RAIN.Core.AI ai) 
	{
		ai.WorkingMemory.SetItem ("pLast", ObjectInteractionUtilities.GetNewLastPosition(ai));
		ai.WorkingMemory.SetItem ("pNew", ObjectInteractionUtilities.GetCurrentPosition(ai));
	}
	
	/*
	private static float GetCurrentMillis()
	{
		DateTime Jan1970 = new DateTime(1970, 1, 1, 0, 0,0,DateTimeKind.Utc);
		TimeSpan javaSpan = DateTime.UtcNow - Jan1970;
		Debug.Log ("current time stamp" + DateTime.UtcNow;
		return (float) javaSpan.TotalMilliseconds;
	}*/
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}