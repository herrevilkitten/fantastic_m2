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

	// the full set dialog that will be spoken between two NPCs (Assumes that conversation will go back and forth
	[RAINSerializableField(Visibility = FieldVisibility.Show, ToolTip="NPC Participants")]
	private List<GameObject> participants = new List<GameObject>();

	private int currentRealDialogCounter = 0;
	private int currentFakeDialogCounter = 0;

	public bool IsFinishedTalking() {
		return currentRealDialogCounter >= clueConversations.Count;
	}

	public string NextClueDialog() {
		string dialog = "";

		if (currentRealDialogCounter < clueConversations.Count) {
			dialog = clueConversations[currentRealDialogCounter++];
		}

		return dialog;
	}

	public GameObject GetCurrentClueTalker() {
		return participants [currentRealDialogCounter % participants.Count];
	}

	public string NextFakeDialog() {
		string dialog = "";

		if (currentFakeDialogCounter < fakeConversations.Count-1) {
			currentFakeDialogCounter = currentFakeDialogCounter+1;
		} else {
			currentFakeDialogCounter = 0;
		}

		dialog = fakeConversations [currentFakeDialogCounter];
		
		return dialog;
	}

	public GameObject GetCurrentFakeTalker() {
		return participants [currentFakeDialogCounter % participants.Count];
	}
}
