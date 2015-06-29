using UnityEngine;
using System.Collections;

abstract public class ClickableObject : InteractiveObject, InteractiveObject.ClickableInteraction
{
	abstract public void OnInteractClick (GameObject actor);

	public void OnMouseEnter ()
	{
		cursorManager.ClickCursor ();
	}
}
