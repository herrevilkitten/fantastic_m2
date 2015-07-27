using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	protected bool highlighted = false;
	protected Dictionary<Material,Shader> allShaders;
	public Shader highlightShader;

	void Awake ()
	{
		if (this.highlightShader == null) {
			this.highlightShader = Shader.Find ("Legacy Shaders/Reflective/Parallax Specular");
		}
		this.allShaders = new Dictionary<Material, Shader> ();
		foreach (Renderer renderer in  GetComponentsInChildren<Renderer> ()) {
			foreach (Material material in renderer.materials) {
				this.allShaders [material] = material.shader;
			}
		}
	}

	public void HighlightObject ()
	{
		foreach (Material material in this.allShaders.Keys) {
			material.shader = highlightShader;
		}
		highlighted = true;
	}

	public void UnhighlightObject ()
	{
		foreach (Material material in this.allShaders.Keys) {
			material.shader = this.allShaders [material];
		}
		highlighted = false;
	}

	public bool IsHightlighted ()
	{
		return highlighted;
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
