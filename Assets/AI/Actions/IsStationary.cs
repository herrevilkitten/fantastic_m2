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

		bool npcIsStationary = ai.Body.transform.position.x == lastPosition.x && 
							   ai.Body.transform.position.y == lastPosition.y &&
							   ai.Body.transform.position.z == lastPosition.z;

		//Debug.Log ("npc is stationary=" + npcIsStationary);

		ai.WorkingMemory.SetItem ("npcLastPosition", ai.Body.transform.position);
		ai.WorkingMemory.SetItem ("trigSecrAnim", npcIsStationary);

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}