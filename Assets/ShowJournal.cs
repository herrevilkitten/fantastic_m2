using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class ShowJournal : MonoBehaviour
{
	public Text journalText;

	// Use this for initialization
	public void UpdateText ()
	{
		TextAsset evidenceText = Resources.Load ("Evidence") as TextAsset;
		JSONArray nodeArray = JSON.Parse (evidenceText.text).AsArray;
		Dictionary<string,JSONNode> evidences = new Dictionary<string, JSONNode> ();

		for (int i = 0; i < nodeArray.Count; ++i) {
			JSONNode node = nodeArray [i];
			evidences [node ["id"].Value] = node;
		}

		string text = "";
		foreach (string evidence in StateManager.EVIDENCES) {
			if (evidences.ContainsKey (evidence)) {
				if (StateManager.instance.HasFlag (evidence + "Removed")) {
					text = text + "* " + evidences [evidence] ["complete"].Value + "\n";
				} else if (StateManager.instance.HasFlag (evidence + "Gathered")) {
					text = text + "* " + evidences [evidence] ["found"].Value + "\n";
				} else {
					text = text + "* " + evidences [evidence] ["notFound"].Value + "\n";
				}
			} else {
				Debug.Log ("No matching evidence for " + evidence);
			}
		}

		journalText.text = text;
	}
}
