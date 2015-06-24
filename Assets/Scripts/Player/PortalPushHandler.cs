using UnityEngine;
using System.Collections;

public class PortalPushHandler : MonoBehaviour, CharacterCollisionHandler
{
	public InventoryManager inventoryManager;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force)
	{
		Debug.Log ("Ran into a " + hit.gameObject.tag + " " + hit.gameObject.name);
		if (hit.gameObject.tag != "Portal") {
			return false;
		}

		switch (hit.gameObject.name) {
		case "Home Sweet Home Portal":
			if (inventoryManager.HasKey ()) {
				Debug.Log ("We have a key!");
				body.constraints = RigidbodyConstraints.None;
				return false;
			}
			break;
		case "Yuk Mountain Portal":
			if (inventoryManager.HasMemory ()) {
				Debug.Log ("We have a memory!");
				body.constraints = RigidbodyConstraints.None;
				return false;
			}
			break;
		case "City Madness Portal":
			if (inventoryManager.HasHope ()) {
				Debug.Log ("We have a hope!");
				body.constraints = RigidbodyConstraints.None;
				return false;
			}
			break;
		}

		return true;
	}
}
