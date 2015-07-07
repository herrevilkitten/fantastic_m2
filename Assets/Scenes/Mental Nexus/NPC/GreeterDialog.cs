using UnityEngine;
using System.Collections;

public class GreeterDialog : TalkableObjectWithDialog
{
	public TextMesh overheadText;

	public void RemoveGreeter ()
	{
		GetComponent<ParticleSystem> ().Play ();
		TextMesh label = Instantiate (overheadText);
		label.transform.position = transform.position + Vector3.up * 2f;
		label.text = "Good luck in\nyour travels.";

		Invoke ("DestroyGreeter", 2f);
	}

	public void DestroyGreeter ()
	{
		Destroy (gameObject);
	}

	public void GainYukMountainKnowledge ()
	{
		StateManager.knowsAboutYukMountain = true;
	}

	override public string GetDialogResourceName ()
	{
		return "Dialog/Greeter";
	}
}
