using UnityEngine;
using System.Collections;

public class HelpDialog : TalkableObjectWithDialog
{

	public override string GetDialogResourceName ()
	{
		return "hints";
	}

	public void ShowHelp ()
	{
		this.OnInteractClick (null);
	}
}
