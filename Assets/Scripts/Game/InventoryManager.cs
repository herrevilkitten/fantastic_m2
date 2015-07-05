using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
	static Canvas inventoryCanvas;
	public static Image key;
	public static Image memory;
	public static Image hope;

	static InventoryManager ()
	{
		inventoryCanvas = GameObject.Find ("InventoryPanel").GetComponent<Canvas> ();
		key = inventoryCanvas.transform.FindChild ("Key").GetComponent<Image> ();
		memory = inventoryCanvas.transform.FindChild ("Memory").GetComponent<Image> ();
		hope = inventoryCanvas.transform.FindChild ("Hope").GetComponent<Image> ();
	}

	public static void PickupKey ()
	{
		key.GetComponent<Image> ().enabled = true;
	}

	public static bool HasKey ()
	{
		return key.GetComponent<Image> ().enabled;
	}

	public static void PickupMemory ()
	{
		memory.GetComponent<Image> ().enabled = true;
	}
	
	public static bool HasMemory ()
	{
		return memory.GetComponent<Image> ().enabled;
	}

	public static void PickupHope ()
	{
		hope.GetComponent<Image> ().enabled = true;
	}
	
	public static bool HasHope ()
	{
		return hope.GetComponent<Image> ().enabled;
	}
}
