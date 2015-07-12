using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using System;

[RAINAction]
public class ShowPopUp : RAINAction
{
	public override void Start (RAIN.Core.AI ai)
	{
		base.Start (ai);
	}
	
	public override ActionResult Execute (RAIN.Core.AI ai)
	{
		string text = ai.WorkingMemory.GetItem<string> ("popUpText");
		if (text == null || text == "") {
			return ActionResult.SUCCESS;
		}

		DialogManager.Floating (ai.Body, text);
		return ActionResult.SUCCESS;
	}
}
