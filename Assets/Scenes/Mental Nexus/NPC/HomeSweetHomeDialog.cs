using UnityEngine;
using System.Collections;

public class HomeSweetHomeDialog : InteractiveObject
{
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
		Debug.Log ("Dialog state: " + dialogState);
		dialogManager.DisableDialogs ();
		switch (dialogState) {
		case 0:
			dialogManager.SetText ("Every door has a key. But not all keys are what they seem. Perhaps the pillars could shed some light.");
			dialogManager.SetDialog (0, "Ok", changeState (2));
			break;
		case 1:
			dialogManager.SetText ("Are you sure you want to go back there?");
			dialogManager.SetDialog (0, "Ok", changeState (2));
			break;
		case 2:
			dialogManager.Hide ();
			break;
		}
	}
	
	override public void Interact (GameObject actor)
	{
		Debug.Log ("Interacting with " + transform);
		if (dialogManager == null) {
			return;
		}
		
		dialogState = inventoryManager.HasKey () ? 1 : 0;
		dialogManager.Show ();
		dialogFSM ();
	}
}
