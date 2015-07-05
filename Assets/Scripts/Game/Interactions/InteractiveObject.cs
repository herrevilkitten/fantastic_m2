using UnityEngine;
using System.Collections;

abstract public class InteractiveObject : MonoBehaviour
{
	public interface ContinuousInteraction
	{
		void OnInteractContinuous (GameObject actor, bool changed);
	}

	public interface ClickableInteraction
	{
		void OnInteractClick (GameObject actor);
	}

	virtual public void OnMouseEnter ()
	{
		CursorManager.UseCursor ();
	}
	
	public void OnMouseExit ()
	{
		CursorManager.DefaultCursor ();
	}
}
