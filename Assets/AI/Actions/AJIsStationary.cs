using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AJIsStationary : RAINAction
{
	private const int TRIGGER_START_ANIMATION = 0;
	private const int ALLOW_ANIMATION_TO_FINISH = 1;
	private const int TRIGGER_STOP_ANIMATION = 2;

	private DetectPlayerPositionAIElement _detectPlayerPosition = null;
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		if (_detectPlayerPosition == null) {
			_detectPlayerPosition = ai.GetCustomElement<DetectPlayerPositionAIElement>();
		}
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		Debug.Log ("Entering IsStationary Logic");
		Vector3 lastPosition = ai.WorkingMemory.GetItem <Vector3> ("npcLastPosition");
		
		if (!_detectPlayerPosition.IsPlayerMoving ()) {
			Debug.Log ("Player is not moving");
			if (_detectPlayerPosition.IsPlayerCloseToNPCForTrigger (ai.Body.transform.position)) {
				Debug.Log ("Player is close to NPC");
				float timeSinceStartOfGame = Time.time;
				
				int isTriggerAnim = IsTimeToTriggerAnimation(ai, timeSinceStartOfGame, 45.0f);
				
				
				if (isTriggerAnim==TRIGGER_START_ANIMATION) {
					Debug.Log ("Trigger animation");
					ai.WorkingMemory.SetItem ("trigSecrAnim", true);	
					ai.WorkingMemory.SetItem ("lastSecretTriggerTime", timeSinceStartOfGame);
				} 
				
				if (isTriggerAnim==ALLOW_ANIMATION_TO_FINISH) {
					Debug.Log ("Continue animation");
					ai.WorkingMemory.SetItem ("trigSecrAnim", true);	
				} 
				
				if (isTriggerAnim==TRIGGER_STOP_ANIMATION) {
					Debug.Log ("Stop trigger animation");
					ai.WorkingMemory.SetItem ("trigSecrAnim", false);
				}
			}
		} else {
			Debug.Log ("Player is moving");
			ai.WorkingMemory.SetItem ("trigSecrAnim", false);
			//reset the last secret trigger time
			Debug.Log ("Reset the last trigger time");
			ai.WorkingMemory.SetItem ("lastSecretTriggerTime", 0);
		}
		
		ai.WorkingMemory.SetItem ("npcLastPosition", ai.Body.transform.position);
		
		Debug.Log ("Exiting IsStationary Logic");
		return ActionResult.SUCCESS;
	}
	
	private int IsTimeToTriggerAnimation(RAIN.Core.AI ai, float timeSinceStartOfGame, float range) 
	{
		float lastSecretTriggerTime = ai.WorkingMemory.GetItem<float> ("lastSecretTriggerTime");
		Debug.Log ("lastSecretTriggerTime=" + lastSecretTriggerTime);
		Debug.Log ("timeSinceStartOfGame - lastSecretTriggerTime = " + (timeSinceStartOfGame - lastSecretTriggerTime));
		if (lastSecretTriggerTime == 0) {
			return TRIGGER_START_ANIMATION;
		} 
		
		if (timeSinceStartOfGame - lastSecretTriggerTime < 15.0f) {
			//let the clip finish playing before deactivating?
			return ALLOW_ANIMATION_TO_FINISH;
		} 
		
		if (timeSinceStartOfGame - lastSecretTriggerTime > range) {
			return TRIGGER_START_ANIMATION;
		} 
		
		return TRIGGER_STOP_ANIMATION;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}