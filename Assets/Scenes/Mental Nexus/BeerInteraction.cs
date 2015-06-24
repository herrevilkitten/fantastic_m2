using UnityEngine;
using System.Collections;

public class BeerInteraction : InteractiveObject
{
	public InventoryManager inventoryManager;

	override public void Interact (GameObject actor)
	{
		inventoryManager.PickupKey ();
		Destroy (gameObject);
	}
}
