using System;
using UnityEngine;
using System.Collections;
using RAIN.Action;
using RAIN.Core;
using RAIN.Serialization;

[RAINSerializableClass, RAINElement("Detect player position ai element")]
public class DetectPlayerPositionAIElement : CustomAIElement {
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "")]
	private float offset = 0.75f;

	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "")]
	private float acceptableRangeToStopChasing = 1.0f;

	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "")]
	private float acceptableRangeToStartTrigger = 1.5f;
	
	private bool bObjectDetected;
	private GameObject goObjectBeingChased;
	private Vector3 pLast;
	private Vector3 pNew;

	public override void AIInit()
	{
		base.AIInit();

	}

	public override void BodyInit()
	{
		base.BodyInit ();
	}

	public void SetObjectBeingChased(GameObject objectBeingChased) 
	{
		bObjectDetected = true;
		goObjectBeingChased = objectBeingChased;
	}

	public void SetNoTarget() 
	{
		bObjectDetected = false;
		goObjectBeingChased = null;
	}

	public Vector3 GetPLast() {
		return pLast;
	}

	public Vector3 GetPNew() {
		return pNew;
	}
	
	public void SetPLast(Vector3 pLast) 
	{
		this.pLast = pLast;
	}

	public void SetPNew(Vector3 pNew) 
	{
		this.pNew = pNew;
	}

	public bool IsPlayerMoving() 
	{
		Vector3 velocity = GetVelocity();
		//Debug.Log ("Current velocity = " + velocity);
		//Debug.Log ("IsLastPositionInitialized(ai) = " + IsLastPositionInitialized (ai));
		//Debug.Log ("velocity.x != 0 = " + (velocity.x != 0));
		//Debug.Log ("velocity.y != 0 = " + (velocity.y != 0));
		//Debug.Log ("velocity.z != 0 = " + (velocity.z != 0));
		return IsLastPositionInitialized() && (velocity.x != 0 || velocity.z != 0);
	}

	public bool IsPlayerCloseToNPCForStopping(Vector3 npcPosition) {
		Vector3 playerPosition = GetCurrentPosition ();
		
		Vector3 difference = playerPosition - npcPosition;
		
		//Debug.Log ("difference = " + difference);
		
		bool xNear = ((-1)*acceptableRangeToStopChasing) <= difference.x && difference.x <= acceptableRangeToStopChasing;
		bool zNear = ((-1)*acceptableRangeToStopChasing) <= difference.z && difference.z <= acceptableRangeToStopChasing;
		
		return xNear && zNear;
	}

	public bool IsPlayerCloseToNPCForTrigger(Vector3 npcPosition) {
		Vector3 playerPosition = GetCurrentPosition ();

		Vector3 difference = playerPosition - npcPosition;
		
		//Debug.Log ("difference = " + difference);
		
		bool xNear = ((-1)*acceptableRangeToStartTrigger) <= difference.x && difference.x <= acceptableRangeToStartTrigger;
		bool zNear = ((-1)*acceptableRangeToStartTrigger) <= difference.z && difference.z <= acceptableRangeToStartTrigger;
		
		return xNear && zNear;
	}
	
	public Vector3 GetVelocity() 
	{
		return (GetCurrentPosition() - GetLastPosition()) / GetTimePassed ();
	}

	public Vector3 GetCurrentPosition() 
	{
		return goObjectBeingChased.transform.position;
	}
	
	public bool IsLastPositionInitialized()  
	{
		Vector3 lastPosition = GetLastPosition ();

		return (lastPosition.x != 0 || lastPosition.y != 0 || lastPosition.z != 0);
		
	}
	
	public Vector3 GetNewLastPosition() 
	{
		return pNew;
	}
	
	public Vector3 GetLastPosition() 
	{
		return pLast;
	}

	public Vector3 GetPositionForNPC() 
	{
		if (IsPlayerMoving ()) {
			return GetHeadoffPosition();
		}

		return GetCurrentPositionWithOffset ();
	}

	public System.Object GetObjectForNPCToFace() 
	{
		if (IsPlayerMoving ()) {
			return GetHeadoffPosition();
		}
		
		return goObjectBeingChased;
	}

	public bool ShouldContinueChasingPlayer(Vector3 npcPosition) 
	{
		if (IsPlayerCloseToNPCForStopping (npcPosition)) {
			return false;
		}

		return true;
	}

	private Vector3 GetHeadoffPosition() {
		Vector3 headoffPosition = new Vector3();
		Vector3 currentPlayerPosition = GetCurrentPosition();
		Vector3 velocity = GetVelocity();
		float getTimePassed = GetTimePassed();
		
		headoffPosition.x = currentPlayerPosition.x - offset + (velocity.x * getTimePassed*4);
		headoffPosition.y = currentPlayerPosition.y;
		headoffPosition.z = currentPlayerPosition.z - offset + (velocity.z * getTimePassed*4);
		return headoffPosition;
	}

	private Vector3 GetCurrentPositionWithOffset() {
		Vector3 headoffPosition = new Vector3();
		Vector3 currentPlayerPosition = GetCurrentPosition();
		Vector3 velocity = GetVelocity();
		
		headoffPosition.x = currentPlayerPosition.x - offset;
		headoffPosition.y = currentPlayerPosition.y;
		headoffPosition.z = currentPlayerPosition.z - offset;

		return headoffPosition;
	}

	public void ResetPlayerPositions() {
		SetPLast (GetNewLastPosition ());
		SetPNew (GetCurrentPosition ());
	}
	
	private float GetTimePassed()
	{
		return Time.fixedDeltaTime;
	}
}
