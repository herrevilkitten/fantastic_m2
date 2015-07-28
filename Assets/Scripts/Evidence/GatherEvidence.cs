using UnityEngine;
using System.Collections;

public class GatherEvidence : UsableAfterTime
{
	public string flag;

	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			StateManager.SetFlag (flag + "Gathered");
			ParticleSystem particleSystem = GetComponent<ParticleSystem> ();
			if (particleSystem != null) {
				particleSystem.Stop ();
			}
			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<Collider> ().enabled = false;
			transform.parent = actor.transform;
			transform.position = transform.parent.position;
		};
	}
}
