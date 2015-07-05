using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

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
		
		ai.WorkingMemory.SetItem ("playerLastPosition", lastPosition);
		ai.WorkingMemory.SetItem ("playerNewPosition", currentPosition);
		
		Debug.Log ("my character position = " + ai.Body.transform.position);
		
		ai.WorkingMemory.SetItem ("headoffPosition", currentPosition);

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}