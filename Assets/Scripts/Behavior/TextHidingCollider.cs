using UnityEngine;
using System.Collections;

public class TextHidingCollider : MonoBehaviour
{
	Light textLighting;
	TextMesh text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<TextMesh> ();
		textLighting = transform.parent.GetComponent<Light> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			if (textLighting != null) {
				textLighting.enabled = false;
			}

			if (textLighting != null) {
				textLighting.enabled = false;
			}
			text.text = "";
		}
	}
}
