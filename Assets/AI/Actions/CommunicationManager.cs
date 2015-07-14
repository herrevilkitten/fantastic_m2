using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Serialization;

[RAINSerializableClass, RAINElement("CommunicationManager")]
public class CommunicationManager : CustomAIElement {

	// the full set dialog that will be spoken between two NPCs (Assumes that conversation will go back and forth
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip="NPC Full dialog")]
	private List<string> conversations = new List<string>();
		
	// NPC Starting conversation
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "NPC Conversation Starter")]
	private GameObject npcStarter = null;

	// NPC Responding to conversation
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "NPC Conversation Responder")]
	private GameObject npcResponder = null;

	private GameObject getTalkingNPC;
	private int currentDialogCounter = 0;


	public string NextDialog() {
		string dialog = "";

		if (currentDialogCounter < conversations.Count) {
			dialog = conversations[currentDialogCounter++];
		}

		return dialog;
	}

	public GameObject GetCurrentTalker() {

		if (currentDialogCounter % 2 == 0) {
			return npcStarter;
		}

		return npcResponder;
	}
}
