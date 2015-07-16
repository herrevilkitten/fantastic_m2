using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {
	private static GameObject withinRangePlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("t")) {
			if (withinRangePlayer != null) {
				Target target = withinRangePlayer.GetComponent<Target>();
				if (target != null) {
					target.Confess();
				}
			} 
		}
	}

	public static void SetLastTarget(GameObject npc) {
		Debug.Log ("Setting npc = " + npc);
		withinRangePlayer = npc;
	}

}
