using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class ChooseNavTarget : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

		Vector3 location = ai.WorkingMemory.GetItem<Vector3> ("location");

//		Debug.Log ("location = " + location);

		if (location.Equals (Vector3.zero) || ai.Motor.IsAt (location)) {
			Vector3 nextPosition = RadioManager.Singleton.RadioForNextPosition (ai);
			
//			Debug.Log ("NextPosition for " + ai.Body.name + " " + nextPosition);

		
			ai.WorkingMemory.SetItem ("location", nextPosition);
			ai.Motor.Speed = 1.5f;

			RAIN.Navigation.Pathfinding.RAINPath myPath;
			ai.Navigator.GetPathTo (nextPosition, 100, 1000, true, out myPath);

			ai.Navigator.CurrentPath = myPath;
			ai.Motor.MoveTo (nextPosition);
		} 
		else {
//			Debug.Log (ai.Body.name + ": Distance to target" + ai.Navigator.PathDistanceToTarget());
//			Debug.Log (ai.Body.name + ": continue moving");
			ai.Motor.MoveTo (location);
		}

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}