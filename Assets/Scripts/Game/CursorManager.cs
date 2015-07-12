using UnityEngine;
using UnityEngine.UI;
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

	static Image crosshairs;

	static CursorData defaultCursor;
	static CursorData talkCursor;
	static CursorData useCursor;
	static CursorData clickCursor;
	static CursorData crosshairsCursor;

	static Texture2D currentCursor;

	// Use this for initialization
	static CursorManager ()
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

		crosshairsCursor = new CursorData (
			Resources.Load ("Cursors/crosshairs") as Texture2D,
			new Vector2 (16, 16)
		);

		GameObject crosshairsObject = GameObject.Find ("FirstPersonCrosshairs");
		if (crosshairsObject != null) {
			crosshairs = crosshairsObject.GetComponent<Image> ();
		}

		Debug.Log ("Default Cursor:    " + defaultCursor.cursor);
		Debug.Log ("Talk Cursor:       " + talkCursor.cursor);
		Debug.Log ("Use Cursor:        " + useCursor.cursor);
		Debug.Log ("Click Cursor:      " + clickCursor.cursor);
		Debug.Log ("Crosshairs Cursor: " + crosshairsCursor.cursor);
		Debug.Log ("1st Person Cursor: " + crosshairs);

		DefaultCursor ();
	}
	
	public static void DefaultCursor ()
	{
		if (defaultCursor == null) {
			return;
		}
		SetCursor (defaultCursor.cursor, defaultCursor.hotspot);
	}

	public static void TalkCursor ()
	{
		if (talkCursor == null) {
			return;
		}
		SetCursor (talkCursor.cursor, talkCursor.hotspot);
	}

	public static void UseCursor ()
	{
		if (useCursor == null) {
			return;
		}
		SetCursor (useCursor.cursor, useCursor.hotspot);
	}
	
	public static void ClickCursor ()
	{
		if (clickCursor == null) {
			return;
		}
		SetCursor (clickCursor.cursor, clickCursor.hotspot);
	}
	
	public static void CrosshairsCursor ()
	{
		if (clickCursor == null) {
			return;
		}
		SetCursor (crosshairsCursor.cursor, clickCursor.hotspot);
	}
	
	public static void SetCursor (Texture2D cursor, Vector2 hotspot)
	{
		if (cursor == null) {
			return;
		}
		currentCursor = cursor;
		Cursor.SetCursor (cursor, hotspot, CursorMode.ForceSoftware);
		if (crosshairs != null) {
			crosshairs.sprite = Sprite.Create (cursor, new Rect (Vector2.zero, new Vector2 (32, 32)), Vector2.zero);
		}
	}

	public static void SetCursor (Texture2D cursor)
	{
		SetCursor (cursor, Vector2.zero);
	}

	public static Texture2D GetCursorTexture ()
	{
		return currentCursor;
	}
}
