using UnityEngine;
using System.Collections;

public class YukMountainDialog : InteractiveObject
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
		string text;
		Debug.Log ("Dialog state: " + dialogState);
		dialogManager.DisableDialogs ();
		switch (dialogState) {
		case 0:
			dialogManager.SetText ("Hello. Is there something I can do for you?");
			if (stateManager.knowsAboutYukMountain) {
				dialogManager.SetDialog (0, "I was told you know how to find things that lost me.", changeState (2));
			} else {
				dialogManager.SetDialog (0, "No thank you.", changeState (1));
			}
			break;
		case 1:
			dialogManager.Hide ();
			break;
		case 2:
			dialogManager.SetText ("That depends on how motivated you are to find them.\n\nAnd how much they want to remain lost.  What do you think you're looking for?");
			dialogManager.SetDialog (0, "Keys.", changeState (3));
			dialogManager.SetDialog (1, "Memories.", changeState (4));
			dialogManager.SetDialog (2, "Hopes.", changeState (5));
			break;
		case 3:
			text = "Keys are the easiest things to find.  They don't move very fast.";
			if (!inventoryManager.HasKey ()) {
				text += " I would look among the lower elevations.";
			} else {
				text += " It looks like you've already found one.";
			}
			text += "\nLooking for anything else?";
			dialogManager.SetText (text);
			dialogManager.SetDialog (0, "Memories.", changeState (4));
			dialogManager.SetDialog (1, "Hopes.", changeState (5));
			dialogManager.SetDialog (2, "Nothing more.", changeState (1));
			break;
		case 4:
			if (!inventoryManager.HasMemory ()) {
				text = "Most of the time, when a memory loses you, it's because you wanted it to get away.  Maybe there's a reason you let it get so far ahead.\n\nIn any case, here's something that might help you unlock some old thoughts.";
				inventoryManager.PickupMemory ();
			} else {
				text = "I can't help you anymore with that. You've got the key -- you just need to unlock the door.";
			}
			text += "\nLooking for anything else?";
			dialogManager.SetText (text);
			dialogManager.SetDialog (0, "Keys.", changeState (3));
			dialogManager.SetDialog (1, "Hopes.", changeState (5));
			dialogManager.SetDialog (2, "Nothing more.", changeState (1));
			break;
		case 5:
			if (!inventoryManager.HasHope ()) {
				text = "Hopes are memories that haven't happened yet. Maybe that's why you're looking for them.";
			} else {
				text = "Only the owner of a hope can make it come true.";
			}
			text += "\nLooking for anything else?";
			dialogManager.SetText (text);
			dialogManager.SetDialog (0, "Keys.", changeState (3));
			dialogManager.SetDialog (1, "Memories.", changeState (4));
			dialogManager.SetDialog (2, "Nothing more.", changeState (1));
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
