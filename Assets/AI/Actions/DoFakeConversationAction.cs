using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class DoFakeConversationAction : RAINAction
{
	private CommunicationManager commManager = null;
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		if (commManager == null) {
			commManager = ai.GetCustomElement<CommunicationManager>();
		}
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		DialogManager.StopConversation();
		
		GameObject currentTalker = commManager.GetCurrentFakeTalker ();
		string message = commManager.NextFakeDialog ();

		DialogManager.Floating(currentTalker, message, 5);

		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}