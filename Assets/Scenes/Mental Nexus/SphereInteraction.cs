using UnityEngine;
using System.Collections;

public class SphereInteraction : MonoBehaviour, InteractiveObject
{
	public Texture2D cursorTexture;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Interact (GameObject actor)
	{
		Rigidbody sphereBody = GetComponent<Rigidbody> ();
		sphereBody.AddForce (actor.transform.forward * 20f);
	}

	void OnMouseEnter ()
	{
		Debug.Log ("MouseEnter: " + cursorTexture);
//		Cursor.visible = false;
		Cursor.SetCursor (cursorTexture, new Vector2 (8, 8), CursorMode.ForceSoftware);
	}

	void OnMouseExit ()
	{
		Debug.Log ("MouseExit");
//		Cursor.visible = true;
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
}
