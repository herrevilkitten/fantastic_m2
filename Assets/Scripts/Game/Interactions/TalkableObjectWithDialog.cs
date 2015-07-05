using UnityEngine;
using System.Collections;

abstract public class TalkableObjectWithDialog : TalkableObject
{
	protected const int DIALOG_START = 0;
	protected const int DIALOG_CLOSE = -1;
	protected int dialogState = DIALOG_START;

	override public void OnInteractClick (GameObject actor)
	{
		dialogState = GetInitialDialogState ();
		DialogManager.Show ();
	}

	protected int GetInitialDialogState ()
	{
		return DIALOG_START;
	}
}
