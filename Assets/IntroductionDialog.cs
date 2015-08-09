using UnityEngine;
using System.Collections;

public class IntroductionDialog : TalkableObjectWithDialog
{
	public override string GetDialogResourceName ()
	{
		return "Cleaner-intro";
	}

	bool dialogShown = false;

	void Start ()
	{
		this.OnInteractClick (null);
	}
}
