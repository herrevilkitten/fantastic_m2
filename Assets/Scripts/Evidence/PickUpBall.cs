using UnityEngine;
using System.Collections;

public class PickUpBall : GatherEvidence
{
	public GameObject prototypeBall;

	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			UnhighlightObject ();

			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<Collider> ().enabled = false;
			transform.parent = actor.transform;
			transform.position = transform.parent.position;
			gameObject.name = "BigBouncyBall";

			InventoryManager.AddItem (gameObject);
		};
	}
}
