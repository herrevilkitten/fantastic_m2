using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class DoConversationAction : RAINAction
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
		if (!commManager.IsFinishedTalking ()) {
			GameObject currentTalker = commManager.GetCurrentClueTalker ();

			string message = commManager.NextClueDialog ();

			//DialogManager.Conversation (currentTalker1.name + ": " + message1, displaySecondMessage);

			DialogManager.Floating(currentTalker, currentTalker.name + ": " + message);
		
		} else {
			DialogManager.StopConversation ();
		}

		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}