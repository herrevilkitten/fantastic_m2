using UnityEngine;
using System.Collections;

public class BeerInteraction : ClickableObject
{
	public InventoryManager inventoryManager;

	override public void OnInteractClick (GameObject actor)
	{
		DialogManager.PopUp ("You have gotten a tasty beer.");
		InventoryManager.PickupKey ();
		Destroy (gameObject);
	}
}
