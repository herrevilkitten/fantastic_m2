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
		DialogManager.StopConversation();

		GameObject currentTalker1 = commManager.GetCurrentClueTalker ();
		string message1 = commManager.NextClueDialog ();
		//Debug.Log ("Current Talker=" + commManager.GetCurrentTalker ());
		//Debug.Log ("Next Dialog=" + commManager.NextDialog ());

		GameObject currentTalker2 = commManager.GetCurrentClueTalker ();
		string message2 = commManager.NextClueDialog ();

		string displaySecondMessage = "";

		if (message2.Length != 0) {
			displaySecondMessage = currentTalker2.name + ": " + message2;
		}

		if (message1.Length > 0) {
			DialogManager.Conversation (currentTalker1.name + ": " + message1, displaySecondMessage);
		} else {
			DialogManager.StopConversation();
		}
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}