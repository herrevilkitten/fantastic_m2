using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class CallBackup : RAINAction
{
	private RadioElement radio;
    public override void Start(RAIN.Core.AI ai)
    {
		base.Start(ai);
		if (radio == null) {
			radio = ai.GetCustomElement<RadioElement>();
		}
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		//Debug.Log ("Player = " + ai.WorkingMemory.GetItem ("Player"));
		//Debug.Log ("Player = " + ((Transform) ai.WorkingMemory.GetItem ("Player")).position);
		radio.RadioMessage ("PlayerPosition", ((Transform) ai.WorkingMemory.GetItem ("Player")).position);
		//Debug.Log ("calling player position");
		radio.RadioMessage ("currentAction", "backup");
		//Debug.Log ("calling backup");
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}