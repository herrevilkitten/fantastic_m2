using UnityEngine;
using System.Collections;

public class GatherEvidence : UsableAfterTime
{
	public string flag;
	public string tooltip;
	public Sprite icon;

	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			StateManager.instance.SetFlag (flag + "Gathered");
			UnhighlightObject ();
			
			ParticleSystem[] particleSystems = transform.parent.GetComponentsInChildren<ParticleSystem> ();
			foreach (ParticleSystem particleSystem in particleSystems) {
				particleSystem.Stop ();
			}
			
			Component halo = GetComponent ("Halo");
			if (halo != null) {
				halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
			}
			
			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<Collider> ().enabled = false;
			transform.parent = actor.transform;
			transform.position = transform.parent.position;

			InventoryManager.AddItem (gameObject);
		};
	}
}
