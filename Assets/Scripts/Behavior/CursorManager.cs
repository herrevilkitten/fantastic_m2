using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{
	class CursorData
	{
		public Texture2D cursor { get; private set; }
		public Vector2 hotspot { get; private set; }

		public CursorData (Texture2D cursor, Vector2 hotspot)
		{
			this.cursor = cursor;
			this.hotspot = hotspot;
		}

		public CursorData (Texture2D cursor) : this(cursor, Vector2.zero)
		{
		}
	}

	/* 
	 * <div>Icons made by <a href="http://www.flaticon.com/authors/freepik" title="Freepik">Freepik</a>, 
	 * <a href="http://www.flaticon.com/authors/elegant-themes" title="Elegant Themes">Elegant Themes</a>, 
	 * <a href="http://www.flaticon.com/authors/icomoon" title="Icomoon">Icomoon</a>
	 * from <a href="http://www.flaticon.com" title="Flaticon">www.flaticon.com</a>
	 * is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0">CC BY 3.0</a></div>
	 */

	CursorData defaultCursor;
	CursorData talkCursor;
	CursorData useCursor;
	CursorData clickCursor;

	Texture2D currentCursor;

	// Use this for initialization
	void Start ()
	{
		defaultCursor = new CursorData (
			Resources.Load ("Cursors/default") as Texture2D,
			new Vector2 (4, 4)
		);

		talkCursor = new CursorData (
			Resources.Load ("Cursors/talk") as Texture2D,
			Vector2.zero
		);
		
		useCursor = new CursorData (
			Resources.Load ("Cursors/use") as Texture2D,
			Vector2.zero
		);

		clickCursor = new CursorData (
			Resources.Load ("Cursors/click") as Texture2D,
			Vector2.zero
		);

		Debug.Log ("Default Cursor: " + defaultCursor.cursor);
		Debug.Log ("Talk Cursor:    " + talkCursor.cursor);
		Debug.Log ("Use Cursor:     " + useCursor.cursor);
		Debug.Log ("Click Cursor:   " + clickCursor.cursor);

		Invoke ("DefaultCursor", 2f);
	}
	
	public void DefaultCursor ()
	{
		if (defaultCursor == null) {
			return;
		}
		SetCursor (defaultCursor.cursor, defaultCursor.hotspot);
	}

	public void TalkCursor ()
	{
		if (talkCursor == null) {
			return;
		}
		SetCursor (talkCursor.cursor, talkCursor.hotspot);
	}

	public void UseCursor ()
	{
		if (useCursor == null) {
			return;
		}
		SetCursor (useCursor.cursor, useCursor.hotspot);
	}
	
	public void ClickCursor ()
	{
		if (clickCursor == null) {
			return;
		}
		SetCursor (clickCursor.cursor, clickCursor.hotspot);
	}
	
	public void SetCursor (Texture2D cursor, Vector2 hotspot)
	{
		if (cursor == null) {
			return;
		}
		Debug.Log ("Setting cursor to " + cursor + " (" + hotspot + ")");
		currentCursor = cursor;
		Cursor.SetCursor (cursor, hotspot, CursorMode.ForceSoftware);
	}

	public void SetCursor (Texture2D cursor)
	{
		SetCursor (cursor, Vector2.zero);
	}

	public Texture2D GetCursorTexture ()
	{
		return currentCursor;
	}
}
