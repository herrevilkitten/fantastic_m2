using UnityEngine;
using System.Collections;

public class StayWithObject : MonoBehaviour
{
	public GameObject target;
	public Vector3 offset = Vector3.zero;

	void Update ()
	{
		if (target != null) {
			transform.position = target.transform.position + offset;	
		}
	}
}
