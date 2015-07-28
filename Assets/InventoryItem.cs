using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryItem : MonoBehaviour
{
	public GameObject evidence;
	public Text tooltipText;
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		EventTrigger eventTrigger = GetComponent<EventTrigger> ();
		EventTrigger.Entry entry;

		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener ((eventData) => {
			if (evidence == null || tooltipText == null) {
				return;
			}

			GatherEvidence gatherEvidence = evidence.GetComponent<GatherEvidence> ();
			if (gatherEvidence == null) {
				return;
			}

			tooltipText.text = gatherEvidence.tooltip;
		});
		eventTrigger.triggers.Add (entry);

		entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.PointerExit;
		entry.callback.AddListener ((eventData) => {
			if (tooltipText == null) {
				return;
			}
			tooltipText.text = "";
		});
		eventTrigger.triggers.Add (entry);
	}
}
