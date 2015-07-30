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

		if (AreTwoVectorsCloseEnough (myCurrentLocation, location)) {
			if (Time.time - myLastLocationTime < 7.0f) {
				return ActionResult.SUCCESS;
			}
		}

		if (location.Equals (Vector3.zero) || AreTwoVectorsCloseEnough(myCurrentLocation, location)) {
			Vector3 nextPosition = RadioManager.Singleton.RadioForNextPosition (ai);
		//	Debug.Log ("NextPosition for " + ai.Body.name + " " + nextPosition );			
			ai.WorkingMemory.SetItem ("location", nextPosition);
			ai.Motor.Speed = 1.5f;

			RAIN.Navigation.Pathfinding.RAINPath myPath;
			ai.Navigator.GetPathTo (nextPosition, 100, 1000, true, out myPath);
//			ai.Motor.AllowOffGraphMovement = false;
			ai.Navigator.CurrentPath = myPath;
			ai.Motor.MoveTo (nextPosition);

		} else {
			RaycastHit hit;
			Vector3 startPoint = new Vector3 (ai.Body.transform.position.x, ai.Body.transform.position.y + 1, ai.Body.transform.position.z);

			if (Physics.Raycast (startPoint, ai.Body.transform.TransformDirection (Vector3.forward), out hit, 15.0f)) {
				Vector3 dir = (location - ai.Body.transform.position).normalized;
				dir += hit.normal * 10;
				Quaternion rot = Quaternion.LookRotation (dir);
				ai.Body.transform.rotation = Quaternion.Slerp (ai.Body.transform.rotation, rot, Time.deltaTime);
			} 


			if ( AreTwoVectorsCloseEnough(myCurrentLocation, myLastLocation) && myLastLocationTime != 0.0f) {
				Vector3 difference = myCurrentLocation - myLastLocation;
//				Debug.Log (ai.Body.name + ": **************************************Looks like im' stuck. Let's do a new location**************************************");

				Vector3 forward = ai.Body.transform.forward;

				//Debug.Log (ai.Body.name + ": forward " + forward);
//				Debug.Log (ai.Body.name + ": myCurrentLocation = " + myCurrentLocation);
				RadioManager.AddStuckLocation(myCurrentLocation);

				Vector3 newlocation = new Vector3();
				System.Random rand = new System.Random();

				bool isBlockedInBack = false;
				float backDistance = (-1)*rand.Next(15, 25);

				bool isBlockedOnRight = false;
				float rightDistance = rand.Next(15, 25);

				bool isBlockedOnLeft = false;
				float leftDistance = (-1)*rand.Next(15, 25);

				if (Physics.Raycast (startPoint, ai.Body.transform.TransformDirection (Vector3.back), out hit, 35.0f)) {
					/*
					Debug.Log (ai.Body.name + ": Who am I hitting behind me = " + hit.transform.name);
					Debug.Log (ai.Body.name + ": hit.transform " + hit.point);
					Debug.Log (ai.Body.name + ": How close am I to the object " + hit.distance);
					Debug.DrawLine (startPoint, hit.point, Color.green);
*/
					backDistance = (-1)*hit.distance;

					//Debug.Log (ai.Body.name + ": I should move back only " + ((-1) *backDistance / 2.0f));
					isBlockedInBack = true;
				}

				if (Physics.Raycast (startPoint, ai.Body.transform.TransformDirection (Vector3.right), out hit, 35.0f)) {
					//Debug.Log (ai.Body.name + ": Who am I hitting right of me = " + hit.transform.name);
					//Debug.Log (ai.Body.name + ": hit.transform " + hit.point);
					//Debug.Log (ai.Body.name + ": How close am I to the object " + hit.distance);
					//Debug.DrawLine (startPoint, hit.point, Color.blue);

					rightDistance = hit.distance;
					//Debug.Log (ai.Body.name + ": I should move back only " + ((+1) *rightDistance / 2.0f));
					isBlockedOnRight = true;
				}

				if (Physics.Raycast (startPoint, ai.Body.transform.TransformDirection (Vector3.left), out hit, 35.0f)) {
					//Debug.Log (ai.Body.name + ": Who am I hitting left of me = " + hit.transform.name);
					//Debug.Log (ai.Body.name + ": hit.transform " + hit.point);
					//Debug.Log (ai.Body.name + ": How close am I to the object " + hit.distance);
					//Debug.DrawLine (startPoint, hit.point, Color.cyan);

					leftDistance = hit.distance;
					//Debug.Log (ai.Body.name + ": I should move back only " + ((-1) *leftDistance / 2.0f));
					isBlockedOnLeft = true;
				}

				if (isBlockedInBack) {
					//Debug.Log ("I'm going back this much = " + backDistance);
					newlocation.z = (float) (myCurrentLocation.z + backDistance);
				}

				newlocation.y = (float) (myCurrentLocation.y);

				if (isBlockedOnLeft && isBlockedOnRight) {
					//Debug.Log ("I'm blocked on both sides");
					newlocation.x = myCurrentLocation.x;
				} else if (isBlockedOnLeft) {
					//Debug.Log ("I'm going to the right=" + rightDistance);
					newlocation.x = myCurrentLocation.x + (rightDistance * (-1)*forward.x);
				} else if (isBlockedOnRight) {
					//Debug.Log ("I'm going to the left=" + leftDistance);
					newlocation.x = myCurrentLocation.x + (leftDistance * (-1)*forward.x);
				}

				if (RadioManager.IsPreviousStuckLocation(newlocation)) {
//					Debug.Log (ai.Body.name + ": Altering new location by a random amount ");
					newlocation.x = newlocation.x + rand.Next(1, 5);
					newlocation.z = newlocation.z + rand.Next(1, 5);
				}

//				Debug.Log (ai.Body.name + ": Going to a new location" + newlocation);
				ai.Motor.FaceAt(newlocation);
				ai.WorkingMemory.SetItem ("location", newlocation);
				/*
				Vector3 newlocation = new Vector3();
				System.Random rand = new System.Random();
				newlocation.x = (float) (myCurrentLocation.x + ((-1) * (forward.x) * rand.Next(5, 15)));
				newlocation.y = myCurrentLocation.y;
				newlocation.z = (float) (myCurrentLocation.z + ((-1) * (forward.z) * rand.Next(0, 5)));

				location = newlocation;
				ai.WorkingMemory.SetItem ("location", newlocation);
				Debug.Log (ai.Body.name + ": Going to a new location" + newlocation);

				location = newlocation;
				*/
			} 
		}

		ai.Motor.MoveTo (location);

		if ((myCurrentLocationTime - myLastLocationTime) > 4.0f) {
//			Debug.Log ("Should record my last position");
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