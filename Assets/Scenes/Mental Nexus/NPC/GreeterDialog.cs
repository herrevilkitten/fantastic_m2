using UnityEngine;
using System.Collections;

public class GreeterDialog : TalkableObject
{
	public StateManager stateManager;
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
			dialogManager.SetText ("Another traveler.  It's been so long since someone has wandered these hallowed halls.  But you're not like the others, you know.");
			dialogManager.SetDialog (0, "What do you mean?", changeState (1));
			break;
		case 1:
			dialogManager.SetText ("The others wandered, gazing with dream-filled eyes.  But your eyes are clear with purpose.\n\nTell me: have you lost something or has something lost you?");
			dialogManager.SetDialog (0, "I have lost something.", changeState (2));
			dialogManager.SetDialog (1, "Something has lost me.", changeState (3));
			break;
		case 2:
			dialogManager.SetText ("This is a place where lost things can sometimes be found.  If it's not in the box behind me, you should continue looking.");
			dialogManager.SetDialog (0, "Thanks.", changeState (4));
			break;
		case 3:
			dialogManager.SetText ("There is looking for things that are lost and then there is looking for things that wish to be lost.  On the hill in the far side is a friend of mine, who can help you with that task.");
			stateManager.knowsAboutYukMountain = true;
			dialogManager.SetDialog (0, "Thanks.", changeState (4));
			break;
		case 4:
			dialogManager.Hide ();
			GetComponent<ParticleSystem> ().Play ();
			Invoke ("RemoveGreeter", 2f);
			break;
		}
	}

	public void RemoveGreeter ()
	{
		Destroy (gameObject);
	}
	
	override public void OnInteractClick (GameObject actor)
	{
		Debug.Log ("Interacting with " + transform);
		if (dialogManager == null) {
			return;
		}

		dialogState = chattedWith ? 100 : 0;
		dialogManager.Show ();
		dialogFSM ();
	}
}
