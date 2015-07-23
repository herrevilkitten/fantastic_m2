using System;
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
		RadioManager.SingletonInstance.Listen (this);
	}

	public void ReceiveMessage(string sender, string variableName, object value) {
		if (!this.sender.Equals (sender)) {
			AI.WorkingMemory.SetItem<object> (variableName, value);
		}
	}

	public void RadioMessage(string sender, string variableName, object value) {
		RadioManager.SingletonInstance.RadioMessage (sender, variableName, value);
	}
}


