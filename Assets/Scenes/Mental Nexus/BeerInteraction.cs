using UnityEngine;
using System.Collections;

public class BeerInteraction : ClickableObject
{
	public InventoryManager inventoryManager;

	override public void OnInteractClick (GameObject actor)
	{
		inventoryManager.PickupKey ();
		Destroy (gameObject);
	}
}
