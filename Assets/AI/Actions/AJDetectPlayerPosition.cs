using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using System;

[RAINAction]
public class AJDetectPlayerPosition : RAINAction
{
	private const float offset = 0.75f;
	private const float acceptableRange = 1.0f;
	private DetectPlayerPositionAIElement _detectPlayerPosition = null;
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		if (_detectPlayerPosition == null) {
			_detectPlayerPosition = ai.GetCustomElement<DetectPlayerPositionAIElement>();
		}
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		/*
		Debug.Log ("Entering Detect Player Position Logic");
		Debug.Log ("pNew = " + ai.WorkingMemory.GetItem<Vector3> ("pNew"));
		Debug.Log ("pLast = " + ai.WorkingMemory.GetItem<Vector3> ("pLast"));
		Debug.Log ("npcLastPosition = " + ai.WorkingMemory.GetItem<Vector3> ("npcLastPosition"));
		*/
		SetHeadoffLocation (ai);
		SetPositionVariables ();
		//Debug.Log ("Exiting Detect Player Position Logic");


		return ActionResult.SUCCESS;
	}
	
	private void SetHeadoffLocation(RAIN.Core.AI ai) 
	{
		//		Debug.Log ("IsPlayerMoving (ai)=" + ObjectInteractionUtilities.IsPlayerMoving (ai));
		bool IsTriggeringSecret = ai.WorkingMemory.GetItem<bool> ("trigSecrAnim");

		Vector3 positionForNPC = _detectPlayerPosition.GetPositionForNPC ();
		System.Object objectToFace = _detectPlayerPosition.GetObjectForNPCToFace ();
		bool continueChasingPlayer = _detectPlayerPosition.ShouldContinueChasingPlayer (ai.Body.transform.position);

		ai.WorkingMemory.SetItem ("headoffPosition", positionForNPC);
		ai.WorkingMemory.SetItem ("objectToFace", objectToFace);
		ai.WorkingMemory.SetItem("continueChasingPlayer", continueChasingPlayer && !IsTriggeringSecret);
		
		/*
		if (_detectPlayerPosition.IsPlayerMoving ()) {

			Vector3 headoffPosition = _detectPlayerPosition.GetHeadoffPosition();
			/*
			Debug.Log ("velocity="+velocity);
			Debug.Log ("Heading off Player at " + headoffPosition);

			ai.WorkingMemory.SetItem ("headoffPosition", headoffPosition);
			ai.WorkingMemory.SetItem ("objectToFace", headoffPosition);
			ai.WorkingMemory.SetItem("continueChasingPlayer", true && !IsTriggeringSecret);
		} else {
			Vector3 headoffPosition = _detectPlayerPosition.GetCurrentPositionWithOffset();
			ai.WorkingMemory.SetItem ("headoffPosition", headoffPosition);
			ai.WorkingMemory.SetItem ("objectToFace", ai.WorkingMemory.GetItem<GameObject> ("objectBeingChased"));
			if (_detectPlayerPosition.IsPlayerCloseToNPCForStopping (ai.Body.transform.position)) 
			{
				ai.WorkingMemory.SetItem("continueChasingPlayer", false);
			}
			else 
			{
				ai.WorkingMemory.SetItem("continueChasingPlayer", true && !IsTriggeringSecret);
			}
		}*/
	}
	
	
	private void SetPositionVariables() 
	{
		_detectPlayerPosition.ResetPlayerPositions ();
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