using UnityEngine;
using System.Collections;
using RAIN.Action;
using RAIN.Core;

public class VariableManager {

	private static void reset(RAIN.Core.AI ai) {
		ai.WorkingMemory.SetItem ("isPatrolling", false);
		ai.WorkingMemory.SetItem ("isWandering", false);
		ai.WorkingMemory.SetItem ("isInteractingWithPlayer", false);
		ai.WorkingMemory.SetItem ("playerLastPosition", new Vector3());
		ai.WorkingMemory.SetItem ("playerNewPosition", new Vector3());
	}

	public static void StartPatrolling(RAIN.Core.AI ai) {
		reset (ai);
		ai.WorkingMemory.SetItem ("isPatrolling", true);
	}

	public static void StartWandering(RAIN.Core.AI ai) {
		reset (ai);
		ai.WorkingMemory.SetItem ("isWandering", true);
	}

	public static void StartInteractingWithPlayer(RAIN.Core.AI ai) {
		reset (ai);
		ai.WorkingMemory.SetItem ("isInteractingWithPlayer", true);
	}
}
