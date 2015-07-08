using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using System;

[RAINAction]
public class DetectPlayerPosition : RAINAction
{
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		Debug.Log ("pNew = " + ai.WorkingMemory.GetItem<Vector3> ("pNew"));
		Debug.Log ("pLast = " + ai.WorkingMemory.GetItem<Vector3> ("pLast"));
		Debug.Log ("npcLastPosition = " + ai.WorkingMemory.GetItem<Vector3> ("npcLastPosition"));

		SetHeadoffLocation (ai);
		SetPositionVariables (ai);
		return ActionResult.SUCCESS;
	}
	
	private void SetHeadoffLocation(RAIN.Core.AI ai) 
	{
		Debug.Log ("IsPlayerMoving (ai)=" + IsPlayerMoving (ai));
		bool IsTriggeringSecret = ai.WorkingMemory.GetItem<bool> ("trigSecrAnim");

		if (IsPlayerMoving (ai)) {
			Vector3 headoffPosition = new Vector3();
			Vector3 currentPlayerPosition = GetCurrentPosition(ai);
			Vector3 velocity = GetVelocity(ai);
			float getTimePassed = GetTimePassed();
			
			headoffPosition.x = currentPlayerPosition.x + (velocity.x * getTimePassed*4);
			headoffPosition.y = currentPlayerPosition.y;
			headoffPosition.z = currentPlayerPosition.z + (velocity.z * getTimePassed*4);

			Debug.Log ("velocity="+velocity);
			Debug.Log ("Heading off Player at " + headoffPosition);
			ai.WorkingMemory.SetItem ("headoffPosition", headoffPosition);
			ai.WorkingMemory.SetItem("continueChasingPlayer", true && !IsTriggeringSecret);
		} else {
			Vector3 headoffPosition = new Vector3();
			Vector3 currentPlayerPosition = GetCurrentPosition(ai);
			Vector3 velocity = GetVelocity(ai);

			headoffPosition.x = currentPlayerPosition.x - 0.5f;
			headoffPosition.y = currentPlayerPosition.y;
			headoffPosition.z = currentPlayerPosition.z - 0.5f;
			ai.WorkingMemory.SetItem ("headoffPosition", headoffPosition);
			if (IsPlayerCloseToNPC(ai)) 
			{
				ai.WorkingMemory.SetItem("continueChasingPlayer", false);
			}
			else 
			{
				ai.WorkingMemory.SetItem("continueChasingPlayer", true && !IsTriggeringSecret);
			}
		}
	}

	private bool IsPlayerCloseToNPC(RAIN.Core.AI ai) {
		Vector3 playerPosition = GetCurrentPosition (ai);
		Vector3 npcPosition = ai.Body.transform.position;
		
		Vector3 difference = playerPosition - npcPosition;
		
		Debug.Log ("difference = " + difference);
		
		bool xNear = -0.9 <= difference.x && difference.x <= 0.9;
		bool zNear = -0.9 <= difference.z && difference.z <= 0.9;
		
		return xNear && zNear;
	}

	private void SetPositionVariables(RAIN.Core.AI ai) 
	{
		ai.WorkingMemory.SetItem ("pLast", GetNewLastPosition(ai));
		ai.WorkingMemory.SetItem ("pNew", GetCurrentPosition(ai));
	}
	
	private bool IsPlayerMoving(RAIN.Core.AI ai) 
	{
		Vector3 velocity = GetVelocity(ai);
		
		return IsLastPositionInitialized(ai) && (velocity.x != 0 || velocity.y != 0 || velocity.z != 0);
	}
	
	private Vector3 GetCurrentPosition(RAIN.Core.AI ai) 
	{
		GameObject player = ai.WorkingMemory.GetItem<GameObject> ("player");
		
		return player.transform.position;
	}
	
	private bool IsLastPositionInitialized(RAIN.Core.AI ai)  
	{
		Vector3 lastPosition = GetLastPosition (ai);
		return (lastPosition.x != 0 || lastPosition.y != 0 || lastPosition.z != 0);
		
	}
	
	private Vector3 GetNewLastPosition(RAIN.Core.AI ai) 
	{
		return ai.WorkingMemory.GetItem<Vector3>("pNew");
	}
	
	private Vector3 GetLastPosition(RAIN.Core.AI ai) 
	{
		return ai.WorkingMemory.GetItem<Vector3>("pLast");
	}
	
	private Vector3 GetVelocity(RAIN.Core.AI ai) 
	{
		return (GetCurrentPosition(ai) - GetLastPosition(ai)) / GetTimePassed ();
	}
	
	private static float GetTimePassed()
	{
		return Time.deltaTime;
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