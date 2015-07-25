using UnityEngine;
using System.Collections;
using System;
using RAIN.Core;

public class RadioManager {
	private static RadioManager singleton = new RadioManager();
	private IList cops = new ArrayList ();
	private IDictionary detections = new SortedList();

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
}
