using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class IsTargetBehind : RAINAction
{
	public override void Start (RAIN.Core.AI ai)
	{
		base.Start (ai);
	}

	// http://forum.unity3d.com/threads/how-do-i-detect-if-an-object-is-in-front-of-another-object.53188/
	public override ActionResult Execute (RAIN.Core.AI ai)
	{
		GameObject target = ai.WorkingMemory.GetItem<GameObject> ("target");
		Vector3 heading = target.transform.position - ai.Body.transform.position;
		float dot = Vector3.Dot (heading, ai.Body.transform.forward);

		if (dot < .5f) {
			return ActionResult.SUCCESS;
		} else {
			return ActionResult.FAILURE;
		}
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}