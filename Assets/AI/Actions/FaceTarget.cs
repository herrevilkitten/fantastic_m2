using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class FaceTarget : RAINAction
{
	public override void Start (RAIN.Core.AI ai)
	{
		base.Start (ai);
	}

	public override ActionResult Execute (RAIN.Core.AI ai)
	{
		Transform body = ai.Body.transform;
		GameObject target = ai.WorkingMemory.GetItem<GameObject> ("target");
		if (target == null) {
			Debug.LogError ("No target defined.");
			return ActionResult.FAILURE;
		}
		Vector3 location = new Vector3 (target.transform.position.x, body.position.y, target.transform.position.z);
		Debug.Log (ai.Body + " look at " + location);
		body.LookAt (body.position - location);
		return ActionResult.SUCCESS;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}