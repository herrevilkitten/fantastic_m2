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
		Debug.Log ("Entering IsStationary Logic");
		Vector3 lastPosition = ai.WorkingMemory.GetItem <Vector3> ("npcLastPosition");

		if (!ObjectInteractionUtilities.IsPlayerMoving (ai)) {
			Debug.Log ("Player is not moving");
			if (ObjectInteractionUtilities.IsPlayerCloseToNPC (ai, 1.0)) {
				Debug.Log ("Player is close to NPC");
				float timeSinceStartOfGame = Time.time;

				if (IsTimeToTriggerAnimation(ai, timeSinceStartOfGame, 30.0f)) {
					ai.WorkingMemory.SetItem ("trigSecrAnim", true);	
					ai.WorkingMemory.SetItem ("lastSecretTriggerTime", timeSinceStartOfGame);
				} else {
					Debug.Log ("Not triggering animation b/c it was done within the last 10 seconds");
					ai.WorkingMemory.SetItem ("trigSecrAnim", false);
				}
			} else {
				Debug.Log ("Player is NOT close to NPC");
				ai.WorkingMemory.SetItem ("trigSecrAnim", false);
			}
		} else {
			Debug.Log ("Player is moving");
			ai.WorkingMemory.SetItem ("trigSecrAnim", false);
		}

		ai.WorkingMemory.SetItem ("npcLastPosition", ai.Body.transform.position);

		Debug.Log ("Exiting IsStationary Logic");
        return ActionResult.SUCCESS;
    }

	private bool IsTimeToTriggerAnimation(RAIN.Core.AI ai, float timeSinceStartOfGame, float range) 
	{
		float lastSecretTriggerTime = ai.WorkingMemory.GetItem<float> ("lastSecretTriggerTime");

		Debug.Log ("timeSinceStartOfGame - lastSecretTriggerTime = " + (timeSinceStartOfGame - lastSecretTriggerTime));
		if (lastSecretTriggerTime == 0) {
			return true;
		} if (timeSinceStartOfGame - lastSecretTriggerTime > range) {
			return true;
		} else {
			return false;
		}
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }

}