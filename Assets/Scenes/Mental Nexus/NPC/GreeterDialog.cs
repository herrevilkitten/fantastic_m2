using UnityEngine;
using System.Collections;

public class GreeterDialog : TalkableObject
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
			DialogManager.SetText ("Another traveler.  It's been so long since someone has wandered these hallowed halls.  But you're not like the others, you know.");
			DialogManager.SetDialog (0, "What do you mean?", changeState (1));
			break;
		case 1:
			DialogManager.SetText ("The others wandered, gazing with dream-filled eyes.  But your eyes are clear with purpose.\n\nTell me: have you lost something or has something lost you?");
			DialogManager.SetDialog (0, "I have lost something.", changeState (2));
			DialogManager.SetDialog (1, "Something has lost me.", changeState (3));
			break;
		case 2:
			DialogManager.SetText ("This is a place where lost things can sometimes be found.  If it's not in the box behind me, you should continue looking.");
			DialogManager.SetDialog (0, "Thanks.", changeState (4));
			break;
		case 3:
			DialogManager.SetText ("There is looking for things that are lost and then there is looking for things that wish to be lost.  On the hill in the far side is a friend of mine, who can help you with that task.");
			StateManager.knowsAboutYukMountain = true;
			DialogManager.SetDialog (0, "Thanks.", changeState (4));
			break;
		case 4:
			DialogManager.Hide ();
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
		dialogState = chattedWith ? 100 : 0;
		DialogManager.Show ();
		dialogFSM ();
	}
}
