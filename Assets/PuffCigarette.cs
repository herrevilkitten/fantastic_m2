using UnityEngine;
using System.Collections;

public class PuffCigarette : MonoBehaviour
{
	public ParticleSystem particleSystem;

	public void Puff (string stuff)
	{
		if (particleSystem == null) {
			return;
		}

		particleSystem.Play ();
	}
}
