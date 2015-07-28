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
		itemImage.rectTransform.anchoredPosition = new Vector2 (0, 0);
	}
}
