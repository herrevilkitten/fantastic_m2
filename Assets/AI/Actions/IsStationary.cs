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

		if (!ObjectInteractionUtilities.IsPlayerMoving (ai)) {
			Debug.Log ("Player is moving = " + ObjectInteractionUtilities.IsPlayerMoving (ai));
			if (ObjectInteractionUtilities.IsPlayerCloseToNPC (ai, 0.5)) {
				Debug.Log ("Player is close to NPC = " + ObjectInteractionUtilities.IsPlayerCloseToNPC (ai, 0.5));
				ai.WorkingMemory.SetItem ("trigSecrAnim", true);
			} else {
				Debug.Log ("Player is NOT close to NPC = " + ObjectInteractionUtilities.IsPlayerCloseToNPC (ai, 0.5));
				ai.WorkingMemory.SetItem ("trigSecrAnim", false);
			}
		} else {
			Debug.Log ("neither");
			ai.WorkingMemory.SetItem ("trigSecrAnim", false);
		}

		ai.WorkingMemory.SetItem ("npcLastPosition", ai.Body.transform.position);


        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }

}