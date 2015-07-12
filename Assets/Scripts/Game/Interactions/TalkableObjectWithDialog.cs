using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

abstract public class TalkableObjectWithDialog : TalkableObject
{
	protected const int DIALOG_START = 0;
	protected const int DIALOG_CLOSE = -1;
	protected int dialogState = DIALOG_START;
	protected Dictionary<string,JSONNode> jsonOptions = new Dictionary<string, JSONNode> ();
	protected JSONNode json;
	protected Dictionary<int,JSONNode> states;

	override public void OnInteractClick (GameObject actor)
	{
		string resourceName = GetDialogResourceName ();

		json = null;
		if (!jsonOptions.ContainsKey (resourceName)) {
			LoadDialog (resourceName);
		}
		if (!jsonOptions.ContainsKey (resourceName)) {
			Debug.LogError ("No dialog found for resource named " + resourceName);
			return;
		}
		json = jsonOptions [resourceName];

		if (json == null) {
			Debug.LogError ("No dialog found for resource named " + resourceName);
			return;
		}

		states = new Dictionary<int, JSONNode> ();
		JSONArray jsonStates = json ["states"].AsArray;
		foreach (JSONNode stateChild in jsonStates.Children) {
			states [stateChild ["state"].AsInt] = stateChild;
		}

		dialogState = GetInitialDialogState ();
		InvokeJson (json ["onEnter"]);
		DialogManager.Show ();
		ShowDialogState ();
	}

	void InvokeJson (JSONNode node)
	{
		if (node == null) {
			return;
		}
		Debug.Log ("Trying to invoke: " + node.ToJSON (0));
		string invoke = node ["invoke"].Value;
		if (invoke == null || invoke == "") {
			return;
		}

		float delay = 0f;
		if (node ["delay"] != null) {
			delay = node ["delay"].AsFloat;
		}
		Invoke (invoke, delay);
	}

	UnityEngine.Events.UnityAction changeState (int state, JSONNode node)
	{
		return () => {
			dialogState = state;
			InvokeJson (node);
			ShowDialogState ();
		};
	}

	void ShowDialogState ()
	{
		DialogManager.DisableDialogs ();

		if (dialogState == DIALOG_CLOSE) {
			DialogManager.Hide ();
			InvokeJson (json ["onLeave"]);
			return;
		}

		JSONNode jsonState;
		if (states.TryGetValue (dialogState, out jsonState)) {
			InvokeJson (jsonState ["onEnter"]);
			DialogManager.SetText (jsonState ["dialog"]);
			JSONArray options = jsonState ["options"].AsArray;
			if (options != null) {
				for (int i = 0; i < options.Count; ++i) {
					JSONNode option = options [i];
					string text = "Ok.";
					int destination = DIALOG_CLOSE;
					string invoke = null;

					if (option ["text"] != null) {
						text = options [i] ["text"];
					}
					
					if (option ["state"] != null) {
						destination = options [i] ["state"].AsInt;
					}
					
					if (option ["invoke"] != null) {
						invoke = options [i] ["invoke"];
					}

					DialogManager.SetDialog (i, text, changeState (destination, option));
				}
			}
		}
	}

	protected int GetInitialDialogState ()
	{
		return DIALOG_START;
	}

	void LoadDialog (string resourceName)
	{
		if (resourceName == null) {
			return;
		}

		// http://stackoverflow.com/questions/21583104/unity-load-text-from-resources
		TextAsset dialogResource = Resources.Load (resourceName) as TextAsset;
		if (dialogResource == null) {
			Debug.LogError ("Unable to load TextAsset resource: " + resourceName);
			return;
		}

		JSONNode results = JSON.Parse (dialogResource.text);
		Debug.Log (resourceName + " = " + results.ToJSON (0));
		if (results ["states"] == null) {
			results = null;
		}

		jsonOptions [resourceName] = results;
	}

	abstract public string GetDialogResourceName ();

}
