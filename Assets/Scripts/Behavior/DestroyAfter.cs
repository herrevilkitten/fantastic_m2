using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour
{
	public float duration;

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, duration);
	}
}
