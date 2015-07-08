using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class IsStationary : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		Vector3 lastPosition = ai.WorkingMemory.GetItem <Vector3> ("npcLastPosition");

		if (!IsPlayerMoving (ai)) {
			Debug.Log ("Player is moving = " + IsPlayerMoving (ai));
			if (IsPlayerCloseToNPC (ai)) {
				Debug.Log ("Player is close to NPC = " + IsPlayerCloseToNPC (ai));
				ai.WorkingMemory.SetItem ("trigSecrAnim", true);
			} else {
				Debug.Log ("Player is NOT close to NPC = " + IsPlayerCloseToNPC (ai));
				ai.WorkingMemory.SetItem ("trigSecrAnim", false);
			}
		} else {
			Debug.Log ("neither");
			ai.WorkingMemory.SetItem ("trigSecrAnim", false);
		}

		ai.WorkingMemory.SetItem ("npcLastPosition", ai.Body.transform.position);


        return ActionResult.SUCCESS;
    }

	private bool IsPlayerCloseToNPC(RAIN.Core.AI ai) {
		Vector3 playerPosition = GetCurrentPlayerPosition (ai);
		Vector3 npcPosition = ai.Body.transform.position;

		Vector3 difference = playerPosition - npcPosition;

		Debug.Log ("difference = " + difference);

		bool xNear = -1.5 <= difference.x && difference.x <= 1.5;
		bool zNear = -1.5 <= difference.z && difference.z <= 1.5;

		return xNear && zNear;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }

	private bool IsPlayerMoving(RAIN.Core.AI ai) 
	{
		Vector3 velocity = GetVelocity(ai);

		Debug.Log ("player velocity = " + velocity);

		return IsLastPositionInitialized(ai) && (velocity.x != 0 || velocity.y != 0 || velocity.z != 0);
	}
	
	private Vector3 GetCurrentPlayerPosition(RAIN.Core.AI ai) 
	{
		GameObject player = ai.WorkingMemory.GetItem<GameObject> ("objectBeingChased");
		
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
		return (GetCurrentPlayerPosition(ai) - GetLastPosition(ai)) / GetTimePassed ();
	}
	
	private static float GetTimePassed()
	{
		return Time.deltaTime;
	}
}