using UnityEngine;
using System.Collections;

abstract public class ClickableObject : InteractiveObject, InteractiveObject.ClickableInteraction
{
	abstract public void OnInteractClick (GameObject actor);

	override public void OnMouseEnter ()
	{
		CursorManager.instance.ClickCursor ();
	}
}
