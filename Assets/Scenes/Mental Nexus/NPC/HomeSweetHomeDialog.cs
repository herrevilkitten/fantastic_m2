using UnityEngine;
using System.Collections;

public class HomeSweetHomeDialog : TalkableObject
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
		Debug.Log ("Dialog state: " + dialogState);
		DialogManager.DisableDialogs ();
		switch (dialogState) {
		case 0:
			DialogManager.SetText ("Every door has a key. But not all keys are what they seem. Perhaps the pillars could shed some light.");
			DialogManager.SetDialog (0, "Ok", changeState (2));
			break;
		case 1:
			DialogManager.SetText ("Are you sure you want to go back there?");
			DialogManager.SetDialog (0, "Ok", changeState (2));
			break;
		case 2:
			DialogManager.Hide ();
			break;
		}
	}
	
	override public void OnInteractClick (GameObject actor)
	{
		dialogState = InventoryManager.HasKey () ? 1 : 0;
		DialogManager.Show ();
		dialogFSM ();
	}
}
