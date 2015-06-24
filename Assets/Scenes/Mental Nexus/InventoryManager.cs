using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : MonoBehaviour
{
	public Image key;
	public Image memory;
	public Image hope;

	public void PickupKey ()
	{
		key.GetComponent<Image> ().enabled = true;
	}

	public bool HasKey ()
	{
		return key.GetComponent<Image> ().enabled;
	}

	public void PickupMemory ()
	{
		memory.GetComponent<Image> ().enabled = true;
	}
	
	public bool HasMemory ()
	{
		return memory.GetComponent<Image> ().enabled;
	}

	public void PickupHope ()
	{
		hope.GetComponent<Image> ().enabled = true;
	}
	
	public bool HasHope ()
	{
		return hope.GetComponent<Image> ().enabled;
	}
}
