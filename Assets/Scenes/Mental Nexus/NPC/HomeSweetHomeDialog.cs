using UnityEngine;
using System.Collections;

public class HomeSweetHomeDialog : TalkableObjectWithDialog
{
	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	override public string GetDialogResourceName ()
	{
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("smoking")) {
			return "Dialog/Smoking";
		} else {
			return "Dialog/NotSmoking";
		}
	}
}
