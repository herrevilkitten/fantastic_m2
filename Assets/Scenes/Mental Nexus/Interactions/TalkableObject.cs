using UnityEngine;
using System.Collections;

abstract public class TalkableObject : InteractiveObject, InteractiveObject.ClickableInteraction
{
	abstract public void OnInteractClick (GameObject actor);

	public void OnMouseEnter ()
	{
		cursorManager.TalkCursor ();
	}
}

