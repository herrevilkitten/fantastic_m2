using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CursorManager : MonoBehaviour
{
	public class CursorData
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

	public static CursorManager instance;

	public Texture2D defaultCursor;
	public Texture2D talkCursor;
	public Texture2D useCursor;
	public Texture2D clickCursor;
	public Texture2D crosshairsCursor;

	public Image crosshairs;

	Texture2D currentCursor;

	void Awake ()
	{
		CursorManager.instance = this;
	}

	public void DefaultCursor ()
	{
		SetCursor (defaultCursor);
	}

	public  void TalkCursor ()
	{
		SetCursor (talkCursor);
	}

	public  void UseCursor ()
	{
		SetCursor (useCursor);
	}
	
	public  void ClickCursor ()
	{
		SetCursor (clickCursor);
	}
	
	public  void CrosshairsCursor ()
	{
		SetCursor (crosshairsCursor);
	}
	
	public  void SetCursor (Texture2D cursor)
	{
		if (cursor == null) {
			return;
		}
		currentCursor = cursor;
		if (crosshairs != null) {
			crosshairs.sprite = Sprite.Create (cursor, new Rect (Vector2.zero, new Vector2 (32, 32)), Vector2.zero);
		}
	}

	public  Texture2D GetCurrentCursor ()
	{
		return currentCursor;
	}
}
