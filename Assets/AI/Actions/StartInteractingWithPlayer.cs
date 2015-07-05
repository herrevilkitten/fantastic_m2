using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class StartInteractingWithPlayer : RAINAction
{
	public StartInteractingWithPlayer() 
	{
		actionName = "StartInteractingWithPlayer";
	}

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		ai.Motor.Stop ();
		VariableManager.StartInteractingWithPlayer (ai);
		//Vector3 targetPosition = ai.WorkingMemory.GetItem<Vector3>("player") - ai.Body.transform.forward;
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}