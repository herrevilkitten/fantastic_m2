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
		Vector3 myPreviousLocation = ai.WorkingMemory.GetItem<Vector3> ("previousLocation");

		float myLastLocationTime = ai.WorkingMemory.GetItem<float> ("myLastLocationTime");
		float myCurrentLocationTime = Time.time;
		float replacedLocationTime = ai.WorkingMemory.GetItem<float> ("replacedLocationTime");

		Debug.Log (ai.Body.name + ": myLastLocationTime = " + myLastLocationTime);
		Debug.Log (ai.Body.name + ": myLastLocation = " + myLastLocation);

		Debug.Log (ai.Body.name + ": myCurrentLocationTime = " + myCurrentLocationTime);
		Debug.Log (ai.Body.name + ": myCurrentLocation = " + myCurrentLocation);

//		Debug.Log (ai.Body.name + ": going to location = " + location);
//		Debug.Log (ai.Body.name + ": ai.Motor.IsAt = " + ai.Motor.IsAt(location));


		if (location.Equals (Vector3.zero) || AreTwoVectorsCloseEnough (myCurrentLocation, location)) {
			Vector3 nextPosition = RadioManager.Singleton.RadioForNextPosition (ai);
			
			Debug.Log ("NextPosition for " + ai.Body.name + " " + nextPosition);
		
			ai.WorkingMemory.SetItem ("location", nextPosition);
			ai.Motor.Speed = 1.5f;

			RAIN.Navigation.Pathfinding.RAINPath myPath;
			ai.Navigator.GetPathTo (nextPosition, 100, 1000, true, out myPath);
//			ai.Motor.AllowOffGraphMovement = false;
			ai.Navigator.CurrentPath = myPath;
			ai.Motor.MoveTo (nextPosition);

			ai.WorkingMemory.RemoveItem("replacedLocationTime");
			ai.WorkingMemory.RemoveItem("previousLocation");
		} else {
			RaycastHit hit;
			Vector3 startPoint = new Vector3 (ai.Body.transform.position.x, ai.Body.transform.position.y + 1, ai.Body.transform.position.z);
			if (Physics.Raycast (startPoint, ai.Body.transform.TransformDirection (Vector3.forward), out hit, 5.0f)) {
				//				Debug.Log (ai.Body.name + ": **************************************something is in front of me. I'm gonna avoid it**************************************");
				Vector3 dir = (location - ai.Body.transform.position).normalized;
				dir += hit.normal * 10;
				Quaternion rot = Quaternion.LookRotation (dir);
				//				Debug.Log("rot : " + rot);
				ai.Body.transform.rotation = Quaternion.Slerp (ai.Body.transform.rotation, rot, Time.deltaTime);


			} 

			if ( AreTwoVectorsCloseEnough(myCurrentLocation, myLastLocation) && myLastLocationTime != 0.0f) {
				Vector3 difference = myCurrentLocation - myLastLocation;
				Debug.Log (ai.Body.name + ": This is why I think i'm stuck = " + difference);

				Debug.Log (ai.Body.name + ": **************************************Looks like im' stuck. Let's do a new location**************************************");

				Vector3 forward = ai.Body.transform.forward;
				Debug.Log (ai.Body.name + ": forward.x = " + forward.x);
				Debug.Log (ai.Body.name + ": forward.y = " + forward.y);
				Debug.Log (ai.Body.name + ": forward.z = " + forward.z);
				Debug.Log (ai.Body.name + ": myCurrentLocation = " + myCurrentLocation);

				Vector3 newlocation = new Vector3();

				newlocation.x = myCurrentLocation.x;
				newlocation.y = myCurrentLocation.y;
				newlocation.z = myCurrentLocation.z;


				System.Random rand = new System.Random();
				newlocation.x = (float) (myCurrentLocation.x + ((-1) * (forward.x) * rand.Next(5, 15)));
				newlocation.y = myCurrentLocation.y;
				newlocation.z = (float) (myCurrentLocation.z + ((-1) * (forward.z) * rand.Next(0, 5)));
				
				if (myPreviousLocation.Equals(Vector3.zero)) {
					ai.WorkingMemory.SetItem ("previousLocation", location);
				}

				location = newlocation;
				ai.WorkingMemory.SetItem ("location", newlocation);
				Debug.Log (ai.Body.name + ": Going to a new location" + newlocation);
				
				ai.WorkingMemory.SetItem ("replacedLocationTime", myCurrentLocationTime);
				location = newlocation;
			} 



		}

		ai.Motor.MoveTo (location);

		if ((myCurrentLocationTime - myLastLocationTime) > 3.0f) {
//			Debug.Log ("Should record my last position");
			ai.WorkingMemory.SetItem ("myLastLocation", myCurrentLocation);
			ai.WorkingMemory.SetItem ("myLastLocationTime", myCurrentLocationTime);
		}
		/*
		if (replacedLocationTime!=0.0f && myCurrentLocationTime - replacedLocationTime > 15.0f) {
			ai.WorkingMemory.SetItem ("location", myPreviousLocation);
			ai.WorkingMemory.RemoveItem("replacedLocationTime");
			ai.WorkingMemory.RemoveItem("previousLocation");
		}
*/

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