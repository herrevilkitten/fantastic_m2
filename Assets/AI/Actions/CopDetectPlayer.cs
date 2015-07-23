using UnityEngine;
using RAIN.Action;
using RAIN.Core;
using RAIN.Entities;
using RAIN.Entities.Aspects;
using RAIN.Perception.Sensors;
using System.Collections;
using System.Collections.Generic;

[RAINAction]
public class CopDetectPlayer : RAINAction
{
	public override void Start(AI ai){
		IList<RAINAspect> matches = ai.Senses.Sense("VisualSensor", "PlayerAspect", RAINSensor.MatchType.ALL);

		Debug.Log ("Looking for matches=" + matches.Count);
		foreach (RAINAspect aspect in matches)
		{
			if (aspect == null)
				continue;

			if (aspect != null) {
				Debug.Log ("aspectpoint=" + aspect.MountPoint);
				ai.WorkingMemory.SetItem("Player", aspect.MountPoint);
				ai.WorkingMemory.SetItem("currentAction", "callBackup");
				break;
			}
		}
	}
}
