using UnityEngine;
using System.Collections;

public class VortexLauncher : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Vector on " + other.gameObject);
//			CharacterController controller = other.gameObject.GetComponent<CharacterController> ();
//			controller.SimpleMove (Vector3.up * 200f);
//			other.attachedRigidbody.AddForce (Vector3.up * 120f);

			//Get an array of components that are of type Rigidbody
			Rigidbody[] bodies = other.gameObject.GetComponentsInChildren<Rigidbody> ();

			//For each of the components in the array, treat the component as a Rigidbody and set its isKinematic property
			foreach (Rigidbody rb in bodies) {
				rb.AddForce (Vector3.up * 20f, ForceMode.VelocityChange);
				rb.isKinematic = false;
			}
			other.gameObject.GetComponent<Animator> ().enabled = false;
			other.gameObject.transform.position += Vector3.back;

			yield return new WaitForSeconds (3f);
			foreach (Rigidbody rb in bodies) {
				rb.isKinematic = true;
			}
			other.gameObject.GetComponent<Animator> ().enabled = true;
		}
	}
}
