using UnityEngine;
using System.Collections;

public class PuffCigarette : MonoBehaviour
{
	public ParticleSystem particleSystem;

	public void Puff (string stuff)
	{
		Debug.Log ("Puffing on a cigarette");
		if (particleSystem == null) {
			return;
		}

		particleSystem.Play ();
	}
}
