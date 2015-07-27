using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class ObserveAction : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		Debug.Log (ai.Body.name + ": Observing the player");
		Vector3 player = ai.WorkingMemory.GetItem<Vector3> ("PlayerPosition");
		Debug.Log (ai.Body.name + ": player" + player);

		if (player != null) {
			Debug.Log ("Look at player");
			ai.Motor.FaceAt(player);
			/*
			Vector3 dir = (player - ai.Body.transform.position).normalized;
			Quaternion rot = Quaternion.LookRotation (dir);
			//				Debug.Log("rot : " + rot);
			ai.Body.transform.rotation = Quaternion.Slerp (ai.Body.transform.rotation, rot, Time.deltaTime);
			*/
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}