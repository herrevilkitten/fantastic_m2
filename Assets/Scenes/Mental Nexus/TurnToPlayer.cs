using UnityEngine;
using System.Collections;

public class TurnToPlayer : MonoBehaviour
{
	void OnTriggerStay (Collider collider)
	{
		if (collider.tag != "Player") {
			return;
		}

		Vector3 playerPosition = collider.transform.position;
		playerPosition.y = transform.parent.position.y;
		transform.parent.LookAt (playerPosition);
	}
}
