using UnityEngine;
using System.Collections;

public class YukMountainDialog : TalkableObject
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
		string text;
		Debug.Log ("Dialog state: " + dialogState);
		DialogManager.DisableDialogs ();
		switch (dialogState) {
		case 0:
			DialogManager.SetText ("Hello. Is there something I can do for you?");
			DialogManager.SetDialog (0, "I was told you know how to find things that lost me.", changeState (2));
			break;
		case 1:
			DialogManager.Hide ();
			break;
		case 2:
			DialogManager.SetText ("That depends on how motivated you are to find them.\n\nAnd how much they want to remain lost.  What do you think you're looking for?");
			DialogManager.SetDialog (0, "Keys.", changeState (3));
			DialogManager.SetDialog (1, "Memories.", changeState (4));
			DialogManager.SetDialog (2, "Hopes.", changeState (5));
			break;
		case 3:
			text = "Keys are the easiest things to find.  They don't move very fast.";
			if (!InventoryManager.HasKey ()) {
				text += " I would look among the lower elevations.";
			} else {
				text += " It looks like you've already found one.";
			}
			text += "\nLooking for anything else?";
			DialogManager.SetText (text);
			DialogManager.SetDialog (0, "Memories.", changeState (4));
			DialogManager.SetDialog (1, "Hopes.", changeState (5));
			DialogManager.SetDialog (2, "Nothing more.", changeState (1));
			break;
		case 4:
			if (!InventoryManager.HasMemory ()) {
				text = "Most of the time, when a memory loses you, it's because you wanted it to get away.  Maybe there's a reason you let it get so far ahead.\n\nIn any case, here's something that might help you unlock some old thoughts.";
				InventoryManager.PickupMemory ();
			} else {
				text = "I can't help you anymore with that. You've got the key -- you just need to unlock the door.";
			}
			text += "\nLooking for anything else?";
			DialogManager.SetText (text);
			DialogManager.SetDialog (0, "Keys.", changeState (3));
			DialogManager.SetDialog (1, "Hopes.", changeState (5));
			DialogManager.SetDialog (2, "Nothing more.", changeState (1));
			break;
		case 5:
			if (!InventoryManager.HasHope ()) {
				text = "Hopes are memories that haven't happened yet. Maybe that's why you're looking for them.";
			} else {
				text = "Only the owner of a hope can make it come true.";
			}
			text += "\nLooking for anything else?";
			DialogManager.SetText (text);
			DialogManager.SetDialog (0, "Keys.", changeState (3));
			DialogManager.SetDialog (1, "Memories.", changeState (4));
			DialogManager.SetDialog (2, "Nothing more.", changeState (1));
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
