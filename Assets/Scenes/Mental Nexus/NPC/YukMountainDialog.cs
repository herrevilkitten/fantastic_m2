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
	}

	override public void OnInteractClick (GameObject actor)
	{
		dialogState = 0;
		DialogManager.Show ();
		dialogFSM ();
	}
}
