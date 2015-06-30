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

	protected CursorManager cursorManager;
	public string gameScripts = "Game Scripts";

	void Awake ()
	{
		cursorManager = GameObject.Find (gameScripts).GetComponent<CursorManager> ();
	}

	virtual public void OnMouseEnter ()
	{
		cursorManager.UseCursor ();
	}
	
	public void OnMouseExit ()
	{
		cursorManager.DefaultCursor ();
	}
}
