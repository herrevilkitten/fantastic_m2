using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class StopPatrolling : RAINAction
{
	public StopPatrolling() 
	{
		actionName = "StopPatrolling";
	}

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		ai.Motor.Stop ();
		ai.WorkingMemory.SetItem ("donePatrolling", true);
		ai.WorkingMemory.SetItem ("doneWandering", false);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}