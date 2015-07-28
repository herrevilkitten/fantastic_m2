using UnityEngine;
using System.Collections;

public class LabeledEvidence : MonoBehaviour
{
	public string label;

	void Start ()
	{
		if (label == null || label == "") {
			label = gameObject.name;
		}
	}
}
