using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using System;

[RAINAction]
public class DetectPlayerPosition : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject player = ai.WorkingMemory.GetItem<GameObject> ("player");
		
		Vector3 currentPosition = new Vector3 ();
		
		currentPosition.x = player.transform.position.x;
		currentPosition.y = player.transform.position.y;
		currentPosition.z = player.transform.position.z;
		
		Vector3 lastPosition = ai.WorkingMemory.GetItem<Vector3>("playerNewPosition");
		float lastPositionTime = ai.WorkingMemory.GetItem<float>("playerNewPositionTime");
		
		ai.WorkingMemory.SetItem ("playerLastPosition", lastPosition);
		ai.WorkingMemory.SetItem ("playerNewPosition", currentPosition);

		ai.WorkingMemory.SetItem ("playerLastPositionTime", lastPositionTime);
		ai.WorkingMemory.SetItem ("playerNewPositionTime", GetCurrentMillis());

		
		Debug.Log ("my character position = " + ai.Body.transform.position);
		Debug.Log ("GetCurrentMillis = " + GetCurrentMillis());
		Debug.Log ("lastPositionTime = " + lastPositionTime);
		Debug.Log ("difference =" + (GetCurrentMillis () - lastPositionTime));
		
		ai.WorkingMemory.SetItem ("headoffPosition", currentPosition);

        return ActionResult.SUCCESS;
    }

	private static float GetCurrentMillis()
	{
		DateTime Jan1970 = new DateTime(1970, 1, 1, 0, 0,0,DateTimeKind.Utc);
		TimeSpan javaSpan = DateTime.UtcNow - Jan1970;
		return (float) javaSpan.TotalMilliseconds;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}