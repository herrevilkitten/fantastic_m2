using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
	public GameObject inventoryPanel;
	public Image inventoryItem;
	public EventSystem eventSystem;
	public Text tooltipText;

	static InventoryManager instance;

	void Start ()
	{
		InventoryManager.instance = this;
	}

	public static void AddItem (GameObject item)
	{
		GatherEvidence gatherEvidence = item.GetComponent<GatherEvidence> ();
		if (gatherEvidence == null) {
			return;
		}

		Image itemImage = Instantiate (instance.inventoryItem);
		InventoryItem inventoryItem = itemImage.GetComponent<InventoryItem> ();
		inventoryItem.evidence = item;
		inventoryItem.eventSystem = instance.eventSystem;
		inventoryItem.tooltipText = instance.tooltipText;

		itemImage.transform.parent = instance.inventoryPanel.transform;

		int offset = -60;
		bool found = false;
		InventoryItem[] items = instance.inventoryPanel.GetComponentsInChildren<InventoryItem> ();
		while (!found) {
			offset = offset + 60;
			found = true;
			foreach (InventoryItem existingItem in items) {
				if (existingItem.GetComponent<Image> ().rectTransform.anchoredPosition.x == offset) {
					found = false;
					break;
				}
			}
		}
		itemImage.rectTransform.anchoredPosition = new Vector2 (offset, 0);
	}

	public static void RemoveItem (GameObject item)
	{
		InventoryItem[] items = instance.inventoryPanel.GetComponentsInChildren<InventoryItem> ();
		foreach (InventoryItem existingItem in items) {
			if (existingItem.evidence == item) {
				Destroy (existingItem.gameObject);
				break;
			}
		}
	}
}
