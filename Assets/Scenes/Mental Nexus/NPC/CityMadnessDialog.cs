using UnityEngine;
using System.Collections;

public class CityMadnessDialog : TalkableObject
{
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
		DialogManager.DisableDialogs ();
		DialogManager.SetText ("");
		switch (dialogState) {
		case 0:
			if (InventoryManager.HasHope ()) {
				DialogManager.SetText ("I can do nothing more.  Pass through the portal!");
				DialogManager.SetDialog (0, "Ok.", changeState (1));
			} else if (InventoryManager.HasKey () && InventoryManager.HasMemory ()) {
				DialogManager.SetText ("Memories are the keys to hope.\n\nWait. That doesn't make any sense.\nWhatever. The important thing is that you have them both.");
				DialogManager.SetDialog (0, "Okay?", changeState (2));
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
				if (!InventoryManager.HasMemory ()) {
					text += "\nYou should talk to my compatriot on top of the mountain about lost things being found.";
				}
				DialogManager.SetText (text);
				DialogManager.SetDialog (0, "I will return.", changeState (1));
			}
			break;
		case 1:
			DialogManager.Hide ();
			break;
		case 2:
			DialogManager.SetText ("I bestow upon you my blessing: 'the gray fires shall not scald your flesh, nor shall you be thrown back'!\nGo now and retrieve the final token!");
			DialogManager.SetDialog (0, "Thanks?", changeState (1));
			break;
		}
	}
	
	override public void OnInteractClick (GameObject actor)
	{
		dialogState = 0;
		DialogManager.Show ();
		dialogFSM ();
	}
}
