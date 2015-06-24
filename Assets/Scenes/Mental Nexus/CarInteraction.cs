using UnityEngine;
using System.Collections;

public class CarInteraction : InteractiveObject
{
	public InventoryManager inventoryManager;
	
	override public void Interact (GameObject actor)
	{
		inventoryManager.PickupHope ();
		Destroy (gameObject);
	}
}
