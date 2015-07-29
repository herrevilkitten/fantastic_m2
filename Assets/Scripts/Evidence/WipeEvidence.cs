using UnityEngine;
using System.Collections;

public class WipeEvidence : UsableEvidence
{
	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			ParticleSystem[] particleSystems = transform.parent.GetComponentsInChildren<ParticleSystem> ();
			foreach (ParticleSystem particleSystem in particleSystems) {
				particleSystem.Stop ();
			}
			
			StateManager.SetFlag (flag + "Removed");
			CursorManager.DefaultCursor ();
			Destroy (gameObject);
		};
	}
}
