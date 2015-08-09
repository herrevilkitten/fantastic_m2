using UnityEngine;
using System.Collections;

abstract public class TalkableObject : InteractiveObject, InteractiveObject.ClickableInteraction
{
	abstract public void OnInteractClick (GameObject actor);

	override public void OnMouseEnter ()
	{
		CursorManager.instance.TalkCursor ();
	}
}

