using UnityEngine;
using System.Collections;

abstract public class UsableObject : InteractiveObject, InteractiveObject.ContinuousInteraction
{
	abstract public void OnInteractContinuous (GameObject actor, bool changed);
}
