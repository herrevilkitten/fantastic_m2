using System;
using UnityEngine;
using RAIN.Core;
using RAIN.Serialization;

[RAINSerializableClass, RAINElement("Radio")]
public class RadioElement : CustomAIElement 
{
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "")]
	private string sender = "";

	public override void AIInit()
	{
		base.AIInit();
		ListenTo ();	
	}

	public void ListenTo() {
		RadioManager.Singleton.Listen (this);
	}

	public void ReceiveMessage(string sender, string variableName, object value) {
		Debug.Log ("Receive Message: " + sender + " " + variableName + " " + value);
		if (!this.sender.Equals (sender)) {
			AI.WorkingMemory.SetItem<object> (variableName, value);
		}
	}

	public void RadioMessage(string variableName, object value) {
		//TODO: Add timestamp
		RadioManager.Singleton.RadioMessage (sender, variableName, value);
	}
}


