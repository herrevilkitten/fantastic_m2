using UnityEngine;
using System.Collections;

public class IntroductionDialog : TalkableObjectWithDialog
{
	public override string GetDialogResourceName ()
	{
		return "Introduction";
	}

	bool dialogShown = false;

	void Update ()
	{
		if (StateManager.IsPlaying () && !dialogShown) {
			dialogShown = true;
			this.OnInteractClick (null);
		}
	}
}
