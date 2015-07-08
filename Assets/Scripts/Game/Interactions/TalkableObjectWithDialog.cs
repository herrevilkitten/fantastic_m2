using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

abstract public class TalkableObjectWithDialog : TalkableObject
{
	protected const int DIALOG_START = 0;
	protected const int DIALOG_CLOSE = -1;
	protected int dialogState = DIALOG_START;
	protected JSONNode json;
	protected Dictionary<int,JSONNode> states;

	override public void OnInteractClick (GameObject actor)
	{
		if (json == null) {
			LoadDialog ();
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
		Debug.Log ("Invoking " + invoke + " after " + delay + " seconds.");
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
		Debug.Log ("Dialog state: " + dialogState);
		DialogManager.DisableDialogs ();

		if (dialogState == DIALOG_CLOSE) {
			DialogManager.Hide ();
			InvokeJson (json ["onLeave"]);
			return;
		}

		JSONNode jsonState;
		if (states.TryGetValue (dialogState, out jsonState)) {
			Debug.Log ("Node: " + jsonState.ToJSON (0));
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

	void LoadDialog ()
	{
		string resourceName = GetDialogResourceName ();
		if (resourceName == null) {
			return;
		}

		// http://stackoverflow.com/questions/21583104/unity-load-text-from-resources
		TextAsset dialogResource = Resources.Load (resourceName) as TextAsset;
		if (dialogResource == null) {
			Debug.Log ("Unable to load TextAsset resource: " + resourceName);
			return;
		}

		json = JSON.Parse (dialogResource.text);
		if (json ["states"] == null) {
			json = null;
		}

		states = new Dictionary<int, JSONNode> ();
		JSONArray jsonStates = json ["states"].AsArray;
		foreach (JSONNode stateChild in jsonStates.Children) {
			states [stateChild ["state"].AsInt] = stateChild;
		}
	}

	abstract public string GetDialogResourceName ();

}
