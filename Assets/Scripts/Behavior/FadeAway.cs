using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeAway : MonoBehaviour
{
	public float duration;
	public TextMesh text;
	Transform camera;
	
	// Use this for initialization
	void Start ()
	{
		camera = GameObject.FindWithTag ("Player").transform.FindChild ("FollowCamera").transform;
		Destroy (gameObject, duration);
	}

	void Update ()
	{
		Vector3 target = new Vector3 (camera.position.x, transform.position.y, camera.position.z);
		transform.LookAt (2 * transform.position - target);
		text.color = new Color (text.color.r, text.color.g, text.color.b, Mathf.Lerp (text.color.a, 0f, Time.deltaTime / duration));
	}
}
