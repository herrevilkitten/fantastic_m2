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
		LabeledEvidence labeledEvidence = GetComponent<LabeledEvidence> ();
		if (labeledEvidence != null) {
			GameObject overheadText = Instantiate (Resources.Load ("HighlightOverheadText") as GameObject);
			overheadText.transform.parent = transform;
			overheadText.transform.position = transform.position + Vector3.up * 1f;
			overheadText.GetComponent<TextMesh> ().text = labeledEvidence.label;
		}

		ParticleSystem particleSystem = GetComponent<ParticleSystem> ();
		if (particleSystem != null) {
			particleSystem.Stop ();
		}

		Component halo = GetComponent ("Halo");
		if (halo != null) {
			halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
		}

		foreach (Material material in this.allShaders.Keys) {
			material.shader = highlightShader;
		}
		highlighted = true;
	}

	public void UnhighlightObject ()
	{
		LabeledEvidence labeledEvidence = GetComponent<LabeledEvidence> ();
		if (labeledEvidence != null) {
			Transform overheadTextTransform = transform.FindChild ("HighlightOverheadText(Clone)");
			if (overheadTextTransform != null) {
				Destroy (overheadTextTransform.gameObject);
			}
		}

		ParticleSystem particleSystem = GetComponent<ParticleSystem> ();
		if (particleSystem != null) {
			particleSystem.Play ();
		}

		Component halo = GetComponent ("Halo");
		if (halo != null) {
			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
		}
		
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
		CursorManager.instance.UseCursor ();
	}
	
	public void OnMouseExit ()
	{
		CursorManager.instance.DefaultCursor ();
	}
}
