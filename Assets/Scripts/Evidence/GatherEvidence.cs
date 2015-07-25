﻿using UnityEngine;
using System.Collections;

public class GatherEvidence : UsableAfterTime
{
	public string flag;

	override protected InteractionManager.OnInteractionSuccess OnInteractionSuccess ()
	{
		return (GameObject actor) => {
			Debug.Log ("Gather that evidence: " + flag);
			StateManager.SetFlag (flag + "Gathered");
			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<Collider> ().enabled = false;
			transform.parent = actor.transform;
			transform.position = transform.parent.position;
		};
	}
}
