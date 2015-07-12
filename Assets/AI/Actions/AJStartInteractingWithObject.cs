using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AJStartInteractingWithObject : RAINAction
{
	private DetectPlayerPositionAIElement _detectPlayerPosition = null;

	public AJStartInteractingWithObject() 
	{
		actionName = "AJStartInteractingWithObject";
	}
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		if (_detectPlayerPosition == null) {
			_detectPlayerPosition = ai.GetCustomElement<DetectPlayerPositionAIElement>();
		}
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		ai.Motor.Stop ();
		VariableManager.StartInteractingWithPlayer (ai);

		_detectPlayerPosition.SetObjectBeingChased (ai.WorkingMemory.GetItem<GameObject> ("objectBeingChased"));

		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}