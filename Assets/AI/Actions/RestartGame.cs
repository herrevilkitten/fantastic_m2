using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RestartGame : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		Animator anim = ai.Body.GetComponent<Animator> ();
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("FinishedArrest")) {

			Transform player = ai.WorkingMemory.GetItem<Transform>("Player");

			float currentTime = Time.time;
			float triggerPlayerAnimTime = ai.WorkingMemory.GetItem<float>("PlayerIsFallingTime");

			if (triggerPlayerAnimTime == 0.0) {
				player.GetComponent<Animator>().SetBool("IsBeingArrested", true);
				ai.WorkingMemory.SetItem("PlayerIsFallingTime", currentTime);
				return ActionResult.SUCCESS;
			}

			if ((currentTime - triggerPlayerAnimTime) > 4.0f && (currentTime - triggerPlayerAnimTime) < 10.0f) {
				StateManager.TurnOnGameOverPanel();
				return ActionResult.SUCCESS;
			}

			if ((currentTime - triggerPlayerAnimTime) > 10.0f) {
				StateManager.TurnOffGameOverPanel();
				Application.LoadLevel (Application.loadedLevel);
				return ActionResult.SUCCESS;
			}
		}
	
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}