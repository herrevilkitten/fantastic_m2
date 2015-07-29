using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class LookAtBall : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		Vector3 ball1 = ai.WorkingMemory.GetItem<Vector3> ("LastBallPositionBall1");
		Vector3 ball2 = ai.WorkingMemory.GetItem<Vector3> ("LastBallPositionBall2");

		if (ball2 != null) {
			ai.Motor.FaceAt (ball2);
		} else if (ball1 != null){
			ai.Motor.FaceAt (ball1);
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}