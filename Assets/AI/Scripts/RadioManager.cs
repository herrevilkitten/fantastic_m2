using UnityEngine;
using System.Collections;
using System;

public class RadioManager {
	private static RadioManager singletonInstance = new RadioManager();
	private ArrayList cops = new ArrayList ();

	private RadioManager() {
	}

	public static RadioManager SingletonInstance {
		get 
		{
			if(singletonInstance == null) {
				singletonInstance = new RadioManager();
			}

			return singletonInstance;
		}
	}

	public void Listen(RadioElement copRadio) {
		cops.Add (copRadio);
	}

	public void RadioMessage(string sender, string messageName, object value) {
		for(int i=0; i<cops.Count; i++) {
			RadioElement element = (RadioElement) cops[i];
			element.ReceiveMessage(sender, messageName, value);
		}
	}
}
