using UnityEngine;
using System.Collections;

public class PortalPushHandler : MonoBehaviour, CharacterCollisionHandler
{
	public bool handleCollision (ControllerColliderHit hit, Rigidbody body, float force)
	{
		Debug.Log ("Ran into a " + hit.gameObject.tag + " " + hit.gameObject.name);
		if (hit.gameObject.tag != "Portal") {
			return false;
		}

		switch (hit.gameObject.name) {
		case "Home Sweet Home Portal":
			if (InventoryManager.HasKey ()) {
				Debug.Log ("We have a key!");
				body.constraints = RigidbodyConstraints.None;
				return false;
			}
			break;
		case "Yuk Mountain Portal":
			if (InventoryManager.HasMemory ()) {
				Debug.Log ("We have a memory!");
				body.constraints = RigidbodyConstraints.None;
				return false;
			}
			break;
		case "City Madness Portal":
			if (InventoryManager.HasHope ()) {
				Debug.Log ("We have a hope!");
				body.constraints = RigidbodyConstraints.None;
				return false;
			}
			break;
		}

		return true;
	}
}
