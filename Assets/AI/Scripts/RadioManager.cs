using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;

public class RadioManager {
	private static RadioManager singleton = new RadioManager();
	private IList cops = new ArrayList ();
	private IDictionary detections = new SortedList();

	private List<GameObject> listOfTargets = new List<GameObject>();

	private RadioManager() {
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

	public void AddTarget(GameObject element) {
		listOfTargets.Add (element);
	}

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
		int nextPosition = rand.Next(0, listOfTargets.Count);
		return listOfTargets [nextPosition].transform.position;
	}
}
