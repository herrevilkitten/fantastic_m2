using UnityEngine;
using System.Collections;
using System;

public class RadioManager {
	private static RadioManager singleton = new RadioManager();
	private ArrayList cops = new ArrayList ();

	private RadioManager() {
	}

	public static RadioManager Singleton {
		get 
		{
			if(singleton == null) {
				singleton = RadioManager();
			}

			return singleton;
		}
	}

	public void Listen(RadioElement copRadio) {
		cops.Add (copRadio);
	}

	public void RadioMessage(string sender, string messageName, object value) {
		for(int i=0; i<cops.Count; i++) {
			RadioElement element = cops[i];
			element.ReceiveMessage(sender, messageName, value);
		}
	}
}
