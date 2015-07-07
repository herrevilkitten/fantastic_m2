using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeAway : MonoBehaviour
{
	public float duration;
	public TextMesh text;
	
	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, duration);
	}

	void Update ()
	{
		Transform player = GameObject.FindWithTag ("Player").transform;
		Vector3 target = new Vector3 (player.position.x, transform.position.y, player.position.z);
		transform.LookAt (2 * transform.position - target);
		text.color = new Color (text.color.r, text.color.g, text.color.b, Mathf.Lerp (text.color.a, 0f, Time.deltaTime / duration));
	}
}
