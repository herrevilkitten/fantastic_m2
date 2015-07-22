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

	protected Renderer originalRenderer;
	protected Shader[] originalShaders;
	protected bool highlighted = false;
	public Shader highlightShader;

	void Awake ()
	{
		this.originalRenderer = GetComponent<Renderer> ();
		if (this.originalRenderer != null) {
			int i = 0;
			this.originalShaders = new Shader[this.originalRenderer.materials.Length];
			foreach (Material material in this.originalRenderer.materials) {
				this.originalShaders [i++] = material.shader;
			}
		}

		if (this.highlightShader == null) {
			this.highlightShader = Shader.Find ("Legacy Shaders/Reflective/Parallax Specular");
		}
	}

	public void HighlightObject ()
	{
		int i = 0;
		foreach (Material material in this.originalRenderer.materials) {
			this.originalRenderer.materials [i++].shader = highlightShader;
		}
		highlighted = true;
	}

	public void UnhighlightObject ()
	{
		int i = 0;
		foreach (Material material in this.originalRenderer.materials) {
			this.originalRenderer.materials [i].shader = this.originalShaders [i];
			i++;
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
