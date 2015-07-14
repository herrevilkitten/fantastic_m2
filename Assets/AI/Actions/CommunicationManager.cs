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
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip="NPC Clue dialog")]
	private List<string> clueConversations = new List<string>();

	// the full set dialog that will be spoken between two NPCs (Assumes that conversation will go back and forth
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip="NPC Fake dialog")]
	private List<string> fakeConversations = new List<string>();

	// NPC Starting conversation
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "NPC Conversation Starter")]
	private GameObject npcStarter = null;

	// NPC Responding to conversation
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip = "NPC Conversation Responder")]
	private GameObject npcResponder = null;

	private GameObject getTalkingNPC;
	private int currentRealDialogCounter = 0;
	private int currentFakeDialogCounter = 0;


	public string NextClueDialog() {
		string dialog = "";

		if (currentRealDialogCounter < clueConversations.Count) {
			dialog = clueConversations[currentRealDialogCounter++];
		}

		return dialog;
	}

	public GameObject GetCurrentClueTalker() {

		if (currentRealDialogCounter % 2 == 0) {
			return npcStarter;
		}

		return npcResponder;
	}

	public string NextFakeDialog() {
		string dialog = "";

		if (currentFakeDialogCounter < fakeConversations.Count) {
			currentFakeDialogCounter = currentFakeDialogCounter+1;
		} else {
			currentFakeDialogCounter = 0;

		}

		dialog = fakeConversations [currentFakeDialogCounter++];
		
		return dialog;
	}

	public GameObject GetCurrentFakeTalker() {
		
		if (currentFakeDialogCounter % 2 == 0) {
			return npcStarter;
		}
		
		return npcResponder;
	}
}
