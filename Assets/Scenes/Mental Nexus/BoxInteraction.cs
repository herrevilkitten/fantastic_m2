using UnityEngine;
using System.Collections;

public class BoxInteraction : MonoBehaviour, InteractiveObject
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
		Rigidbody boxBody = GetComponent<Rigidbody> ();
		Debug.Log ("Interacting with " + boxBody);
		boxBody.AddForce (transform.up * 40f);
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
