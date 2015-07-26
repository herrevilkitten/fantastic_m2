using UnityEngine;
using System.Collections;

public class ObstacleAvoidance : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		float length = 10;

		Vector3 startPoint = new Vector3 (transform.position.x, transform.position.y+1, transform.position.z);

		if (Physics.Raycast (startPoint, transform.TransformDirection (Vector3.forward), out hit, length)) {
			Debug.Log (transform.name + ": FRONT " + startPoint + "-> " + hit.transform.name + ": " + hit.point);

			Debug.DrawLine (startPoint, hit.point, Color.cyan);
		}

		if (Physics.Raycast (startPoint, transform.TransformDirection (Vector3.back), out hit, length)) {
			Debug.Log (transform.name + ": BACK " + startPoint + "-> " + hit.transform.name + ": " + hit.point);
			Debug.DrawLine (startPoint, hit.point, Color.green);
		} 

		if (Physics.Raycast (startPoint, transform.TransformDirection (Vector3.left), out hit, length)) {
			Debug.Log (transform.name + ": LEFT " + startPoint + "-> " + hit.transform.name + ": " + hit.point);
			Debug.DrawLine (startPoint, hit.point, Color.red);
		} 

		if (Physics.Raycast (startPoint, transform.TransformDirection (Vector3.right), out hit, length)) {
			Debug.Log (transform.name + ": RIGHT " + startPoint + "-> " + hit.transform.name + ": " + hit.point);
			Debug.DrawLine (startPoint, hit.point, Color.yellow);
		} 
		/*
		if (Physics.Raycast (startPoint, transform.TransformDirection (Vector3.up), out hit, length)) {
			Debug.Log (transform.name + ": UP " + startPoint + "-> " + hit.transform.name + ": " + hit.point);
			Debug.DrawLine (startPoint, hit.point, Color.blue);
		} 

		if (Physics.Raycast (startPoint, transform.TransformDirection (Vector3.down), out hit, length)) {
			Debug.Log (transform.name + ": DOWN " + startPoint + "-> " + hit.transform.name + ": " + hit.point);
			Debug.DrawLine (startPoint, hit.point, Color.black);
		} 
		*/
	}
}
