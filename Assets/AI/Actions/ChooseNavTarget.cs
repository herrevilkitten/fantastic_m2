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
		Vector3 myLastLocation = ai.WorkingMemory.GetItem<Vector3> ("myLastLocation");
		Vector3 myCurrentLocation = ai.Body.transform.position;

		float myLastLocationTime = ai.WorkingMemory.GetItem<float> ("myLastLocationTime");
		float myCurrentLocationTime = Time.time;


		Debug.Log (ai.Body.name + ": myLastLocation = " + myLastLocation);
		Debug.Log (ai.Body.name + ": myCurrentLocation = " + myCurrentLocation);
		Debug.Log (ai.Body.name + ": going to location = " + location);
		Debug.Log (ai.Body.name + ": ai.Motor.IsAt = " + ai.Motor.IsAt(location));

		if (location.Equals (Vector3.zero) || ai.Motor.IsAt (location)) {
			Vector3 nextPosition = RadioManager.Singleton.RadioForNextPosition (ai);
			
//			Debug.Log ("NextPosition for " + ai.Body.name + " " + nextPosition);

		
			ai.WorkingMemory.SetItem ("location", nextPosition);
			ai.Motor.Speed = 1.5f;

			RAIN.Navigation.Pathfinding.RAINPath myPath;
			ai.Navigator.GetPathTo (nextPosition, 100, 1000, true, out myPath);

			ai.Navigator.CurrentPath = myPath;
			ai.Motor.MoveTo (nextPosition);
		} else {
			RaycastHit hit;
			Vector3 startPoint = new Vector3 (ai.Body.transform.position.x, ai.Body.transform.position.y + 1, ai.Body.transform.position.z);
			if (Physics.Raycast (startPoint, ai.Body.transform.TransformDirection (Vector3.forward), out hit, 8.0f)) {
				Debug.Log ("tag = " + hit.transform.tag);

				Debug.Log (ai.Body.name + ": **************************************something is in front of me. I'm gonna avoid it**************************************");
				Vector3 dir = (location - ai.Body.transform.position).normalized;
				dir += hit.normal * 20;
				Quaternion rot = Quaternion.LookRotation (dir);
				Debug.Log("rot : " + rot);
				ai.Body.transform.rotation = Quaternion.Slerp (ai.Body.transform.rotation, rot, Time.deltaTime);
			}

			if ( AreTwoVectorsCloseEnough(myCurrentLocation, myLastLocation)) {
				Debug.Log (ai.Body.name + ": **************************************Looks like im' stuck. Gonna turn right**************************************");

				ai.Body.transform.rotation = Quaternion.Slerp (ai.Body.transform.rotation, Quaternion.LookRotation(Vector3.right), Time.deltaTime);
				Vector3 newlocation = new Vector3();
				System.Random rand = new System.Random();
				newlocation.x = (float) (myCurrentLocation.x + rand.Next(-5, 5) + rand.NextDouble());
				newlocation.y = myCurrentLocation.y;
				newlocation.z = (float) (myCurrentLocation.z + rand.Next(-5, 5) + rand.NextDouble());

				ai.WorkingMemory.SetItem ("previousLocation", location);
				location = newlocation;
				ai.WorkingMemory.SetItem ("location", newlocation);
				Debug.Log (ai.Body.name + ": Going to a new location" + newlocation);
			}

			ai.Motor.MoveTo (location);
		}

		if (myCurrentLocationTime - myLastLocationTime > 2.0f) {
			Debug.Log ("Should record my last position");
			ai.WorkingMemory.SetItem ("myLastLocation", myCurrentLocation);
			ai.WorkingMemory.SetItem ("myLastLocationTime", myCurrentLocationTime);
		}


		return ActionResult.SUCCESS;
    }

	private bool AreTwoVectorsCloseEnough(Vector3 vec1, Vector3 vec2, double range=0.1f) {
		Vector3 difference = vec1 - vec2;
		
		bool xNear = ((-1)*range) <= difference.x && difference.x <= range;
		bool zNear = ((-1)*range) <= difference.z && difference.z <= range;
		
		return xNear && zNear;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}