using UnityEngine;
using System.Collections;

public class ObjectHighlightMover : MonoBehaviour
{
	public Transform highlightedObject;

	void UpdateLate ()
	{
		if (highlightedObject != null) {
			transform.position = highlightedObject.transform.position;
			transform.Rotate (Vector3.up);
		}
	}
}
