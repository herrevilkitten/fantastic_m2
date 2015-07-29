using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;

public class RadioManager {
	private static RadioManager singleton = new RadioManager();
	private IList cops = new ArrayList ();
	private IDictionary detections = new SortedList();
	private System.Object thisLock = new System.Object();
	private static ArrayList tempStuckLocations = new ArrayList();
	private static ArrayList permStuckLocations = new ArrayList ();

	private static ArrayList tempDestLocations = new ArrayList();
	private static ArrayList permDestLocations = new ArrayList ();

	//private List<GameObject> listOfTargets = new List<GameObject>();

	private RadioManager() {
	}

	public static void AddDestLocation(Vector3 location) {
		if (tempDestLocations.Contains (location)) {
			permDestLocations.Add (location);
		}
		
		tempDestLocations.Add (location);
	}
	
	public static bool IsPreviousDestLocation(Vector3 location) {
		return permDestLocations.Contains (location);
	}
	/*
	public static void RemoveStuckDestination(Vector3 location) {
		return permDestLocations.Remove (location);
	}
*/


	public static void AddStuckLocation(Vector3 location) {
		if (tempStuckLocations.Contains (location)) {
			permStuckLocations.Add (location);
		}

		tempStuckLocations.Add (location);
	}

	public static bool IsPreviousStuckLocation(Vector3 location) {
		return permStuckLocations.Contains (location);
	}

	public static RadioManager Singleton {
		get 
		{
			if(singleton == null) {
				singleton = new RadioManager();
			}

			return singleton;
		}
	}
	/*
	public void AddTarget(GameObject element) {
		listOfTargets.Add (element);
	}
*/
	public void Listen(RadioElement copRadio) {
		//Debug.Log ("Listening");
		cops.Add (copRadio);
	}

	public void RadioMessage(string sender, string messageName, object value) {
		for(int i=0; i<cops.Count; i++) {
			RadioElement element = (RadioElement) cops[i];
			element.ReceiveMessage(sender, messageName, value);
		}
	}

	public void RadioDispatcher(AI cop, Transform player, float detectTime) {
		StateManager.AddSuspicion (10);
	}

	public void RadioReduceDetection(AI cop) {
		StateManager.ReduceDetection(cop.Body.name);
	}

	public void RadioAddDetection(AI cop) {
		StateManager.AddDetection(cop.Body.name);
	}

	public Vector3 RadioForNextPosition(AI ai) {
		System.Random rand = new System.Random ();
		int nextPosition = rand.Next(0, StateManager.stateManager.targets.Length);

		return GetNextPosition(ai, nextPosition);
	}

	private Vector3 GetNextPosition(AI ai, int nextPosition) {
		/*
		if (listOfTargets.Count > 0 && listOfTargets [0] == null) {
			lock (thisLock) {
				listOfTargets.Clear ();
				RadioElement elem = ai.GetCustomElement<RadioElement> ();
				elem.AIInit ();
			}
		}
*/
		return StateManager.stateManager.targets [nextPosition].transform.position; 
	}


	//TODO: refactor this into a utilities class
	private bool AreTwoVectorsCloseEnough(Vector3 vec1, Vector3 vec2, double range=0.1f) {
		Vector3 difference = vec1 - vec2;
		
		bool xNear = ((-1)*range) <= difference.x && difference.x <= range;
		bool zNear = ((-1)*range) <= difference.z && difference.z <= range;
		
		return xNear && zNear;
	}
}
