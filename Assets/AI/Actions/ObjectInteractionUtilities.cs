using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using System;

public class ObjectInteractionUtilities {
	public static bool IsPlayerCloseToNPC(RAIN.Core.AI ai, double range) {
		Vector3 playerPosition = GetCurrentPosition (ai);
		Vector3 npcPosition = ai.Body.transform.position;
		
		Vector3 difference = playerPosition - npcPosition;
		
//		Debug.Log ("difference = " + difference);
		
		bool xNear = ((-1)*range) <= difference.x && difference.x <= range;
		bool zNear = ((-1)*range) <= difference.z && difference.z <= range;
		
		return xNear && zNear;
	}
	

	
	public static bool IsPlayerMoving(RAIN.Core.AI ai) 
	{
		Vector3 velocity = GetVelocity(ai);
		//Debug.Log ("Current velocity = " + velocity);
		//Debug.Log ("IsLastPositionInitialized(ai) = " + IsLastPositionInitialized (ai));
		//Debug.Log ("velocity.x != 0 = " + (velocity.x != 0));
		//Debug.Log ("velocity.y != 0 = " + (velocity.y != 0));
		//Debug.Log ("velocity.z != 0 = " + (velocity.z != 0));
		return IsLastPositionInitialized(ai) && (velocity.x != 0 || velocity.z != 0);
	}
	
	public static Vector3 GetCurrentPosition(RAIN.Core.AI ai) 
	{
		GameObject player = ai.WorkingMemory.GetItem<GameObject> ("objectBeingChased");
		
		return player.transform.position;
	}
	
	public static bool IsLastPositionInitialized(RAIN.Core.AI ai)  
	{
		Vector3 lastPosition = GetLastPosition (ai);
		Debug.Log ("lastPosition = " + lastPosition);
		return (lastPosition.x != 0 || lastPosition.y != 0 || lastPosition.z != 0);
		
	}
	
	public static Vector3 GetNewLastPosition(RAIN.Core.AI ai) 
	{
		return ai.WorkingMemory.GetItem<Vector3>("pNew");
	}
	
	public static Vector3 GetLastPosition(RAIN.Core.AI ai) 
	{
		return ai.WorkingMemory.GetItem<Vector3>("pLast");
	}
	
	public static Vector3 GetVelocity(RAIN.Core.AI ai) 
	{
		return (GetCurrentPosition(ai) - GetLastPosition(ai)) / GetTimePassed ();
	}
	
	public static float GetTimePassed()
	{
//		Debug.Log ("Time.fixedDeltaTime = " + Time.fixedDeltaTime);
		return Time.fixedDeltaTime;
	}
}
