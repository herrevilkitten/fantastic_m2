using UnityEngine;
using System.Collections;

public class CarInteraction : ClickableObject
{
	public InventoryManager inventoryManager;
	
	override public void OnInteractClick (GameObject actor)
	{
		InventoryManager.PickupHope ();
		Destroy (gameObject);
	}
}
