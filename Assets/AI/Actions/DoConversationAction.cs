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
		GameObject currentTalker = commManager.GetCurrentTalker ();
		string message = commManager.NextDialog ();
		//Debug.Log ("Current Talker=" + commManager.GetCurrentTalker ());
		//Debug.Log ("Next Dialog=" + commManager.NextDialog ());

		DialogManager.Floating (currentTalker, message);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}