using UnityEngine;
using System.Collections;

abstract public class InteractiveObject : MonoBehaviour
{
	public CursorManager cursorManager;
	public string gameScripts = "Game Scripts";
	public Texture2D interactionCursor;
	public Vector2 interactionHotspot;

	abstract public void Interact (GameObject actor);

	void Awake ()
	{
		cursorManager = GameObject.Find (gameScripts).GetComponent<CursorManager> ();
	}

	void OnMouseEnter ()
	{
		if (interactionCursor == null) {
			interactionCursor = cursorManager.interactionCursor;
		}
		if (interactionHotspot == null) {
			interactionHotspot = Vector2.zero;
		}
		cursorManager.SetCursor (interactionCursor);
	}
	
	void OnMouseExit ()
	{
		cursorManager.SetDefaultCursor ();
	}
}
