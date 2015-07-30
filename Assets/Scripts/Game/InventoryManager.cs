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
	public GameObject[] initialInventory;

	static InventoryManager instance;

	void Start ()
	{
		InventoryManager.instance = this;
		if (inventoryPanel != null) {
			foreach (Transform child in inventoryPanel.transform) {
				Destroy (child.gameObject);
			}
		}

		foreach (GameObject item in initialInventory) {
			InventoryManager.AddItem (item);
		}
	}

	public static void AddItem (GameObject item)
	{
		GatherEvidence gatherEvidence = item.GetComponent<GatherEvidence> ();
		if (gatherEvidence == null) {
			return;
		}

		Image itemImage = Instantiate (instance.inventoryItem);
		InventoryItem inventoryItem = itemImage.GetComponent<InventoryItem> ();
		itemImage.sprite = gatherEvidence.icon;
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

	public static void RemoveItem (string name)
	{
		InventoryItem[] items = instance.inventoryPanel.GetComponentsInChildren<InventoryItem> ();
		foreach (InventoryItem existingItem in items) {
			if (existingItem.evidence.name == name) {
				Destroy (existingItem.gameObject);
				break;
			}
		}
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

	public static bool HasItem (string name)
	{
		InventoryItem[] items = instance.inventoryPanel.GetComponentsInChildren<InventoryItem> ();
		foreach (InventoryItem existingItem in items) {
			if (existingItem.evidence.name == name) {
				return true;
			}
		}
		return false;
	}

	public static bool HasItem (GameObject item)
	{
		InventoryItem[] items = instance.inventoryPanel.GetComponentsInChildren<InventoryItem> ();
		foreach (InventoryItem existingItem in items) {
			if (existingItem.evidence == item) {
				return true;
			}
		}
		return false;
	}
}
