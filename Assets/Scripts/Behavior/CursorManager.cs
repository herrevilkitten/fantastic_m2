using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{
	public Texture2D defaultCursor;
	public Vector2 defaultHotspot;
	public Texture2D interactionCursor;
	Texture2D currentCursor;

	// Use this for initialization
	void Start ()
	{
		Invoke ("SetDefaultCursor", 2f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetDefaultCursor ()
	{
		if (defaultCursor == null) {
			return;
		}
		SetCursor (defaultCursor);
	}

	public void SetCursor (Texture2D cursor)
	{
		if (cursor == null) {
			return;
		}
		currentCursor = cursor;
		Cursor.SetCursor (cursor, Vector2.zero, CursorMode.ForceSoftware);
	}

	public Texture2D GetCursor ()
	{
		return currentCursor;
	}
}
