using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class FinishArrest : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		Debug.Log ("Finish Arrest starts");
		if (IsPlayerCloseToNPC (ai, 1.5f)) {
			Debug.Log ("Trigger Arrest Sequence");
			ai.WorkingMemory.SetItem ("trigArrestSequence", true);	
		} else {
			Debug.Log ("Stop Trigger Arrest Sequence");
			ai.WorkingMemory.SetItem ("trigArrestSequence", false);	
		}

		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
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