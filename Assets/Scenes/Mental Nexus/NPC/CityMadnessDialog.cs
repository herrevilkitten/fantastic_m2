﻿using UnityEngine;
using System.Collections;

public class CityMadnessDialog : InteractiveObject
{
	public StateManager stateManager;
	public InventoryManager inventoryManager;
	public DialogManager dialogManager;
	int dialogState = 0;
	bool chattedWith;
	
	UnityEngine.Events.UnityAction changeState (int state)
	{
		return () => {
			dialogState = state;
			dialogFSM ();
		};
	}
	
	void dialogFSM ()
	{
		string text = "";
		Debug.Log ("Dialog state: " + dialogState);
		dialogManager.DisableDialogs ();
		dialogManager.SetText ("");
		switch (dialogState) {
		case 0:
			if (inventoryManager.HasHope ()) {
				dialogManager.SetText ("I can do nothing more.  Pass through the portal!");
				dialogManager.SetDialog (0, "Ok.", changeState (1));
			} else if (inventoryManager.HasKey () && inventoryManager.HasMemory ()) {
				dialogManager.SetText ("Memories are the keys to hope.\n\nWait. That doesn't make any sense.\nWhatever. The important thing is that you have them both.");
				dialogManager.SetDialog (0, "Okay?", changeState (2));
			} else {
				switch (Random.Range (0, 4)) {
				case 0:
					text = "You look familiar for some reason.";
					break;
				case 1:
					text = "Do you really want to see what's beyond the door?";
					break;
				case 2:
					text = "Every lock has a key. Not every key has a lock.";
					break;
				case 3:
					text = "I feel that we've talked before.";
					break;
				}
				text += "\nThere are rules and there are times to break rules. But this is not one of those times. You must bring me two things before I can send you on your way.";
				if (!inventoryManager.HasMemory ()) {
					text += "\nYou should talk to my compatriot on top of the mountain about lost things being found.";
					stateManager.knowsAboutYukMountain = true;
				}
				dialogManager.SetText (text);
				dialogManager.SetDialog (0, "I will return.", changeState (1));
			}
			break;
		case 1:
			dialogManager.Hide ();
			break;
		case 2:
			dialogManager.SetText ("I bestow upon you my blessing: 'the gray fires shall not scald your flesh, nor shall you be thrown back'!\nGo now and retrieve the final token!");
			stateManager.canPassBarrier = true;
			dialogManager.SetDialog (0, "Thanks?", changeState (1));
			break;
		}
	}
	
	override public void Interact (GameObject actor)
	{
		Debug.Log ("Interacting with " + transform);
		if (dialogManager == null) {
			return;
		}
		
		dialogState = 0;
		dialogManager.Show ();
		dialogFSM ();
	}
}