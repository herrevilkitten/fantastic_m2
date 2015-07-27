﻿using UnityEngine;
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
		Debug.Log ("Evidence text = " + evidenceText.text);
		JSONArray nodeArray = JSON.Parse (evidenceText.text).AsArray;
		Debug.Log ("Evidence node = " + nodeArray.ToJSON (0));
		Dictionary<string,JSONNode> evidences = new Dictionary<string, JSONNode> ();

		for (int i = 0; i < nodeArray.Count; ++i) {
			JSONNode node = nodeArray [i];
			evidences [node ["id"].Value] = node;
		}

		Debug.Log ("Evidences: " + evidences);

		string text = "";
		foreach (string evidence in StateManager.EVIDENCES) {
			if (evidences.ContainsKey (evidence)) {
				Debug.Log ("Evidence: " + evidences [evidence].ToJSON (0));
				if (StateManager.HasFlag (evidence + "Removed")) {
					text = text + "* " + evidences [evidence] ["complete"].Value + "\n";
				} else if (StateManager.HasFlag (evidence + "Gathered")) {
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
