using UnityEngine;
using System.Collections;
using RAIN.Action;
using RAIN.Core;

public class VariableManager {

	private static void reset(RAIN.Core.AI ai) {
		ai.WorkingMemory.SetItem ("donePatrolling", true);
		ai.WorkingMemory.SetItem ("doneWandering", true);
		ai.WorkingMemory.SetItem ("doneWithPlayer", true);
	}

	public static void StartPatrolling(RAIN.Core.AI ai) {
		reset (ai);
		ai.WorkingMemory.SetItem ("donePatrolling", false);
	}

	public static void StartWandering(RAIN.Core.AI ai) {
		reset (ai);
		ai.WorkingMemory.SetItem ("doneWandering", false);
	}

	public static void StartInteractingWithPlayer(RAIN.Core.AI ai) {
		reset (ai);
		ai.WorkingMemory.SetItem ("doneWithPlayer", false);
	}
}
