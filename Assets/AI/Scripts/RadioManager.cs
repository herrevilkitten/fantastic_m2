using UnityEngine;
using System.Collections;
using System;
using RAIN.Core;

public class RadioManager {
	private static RadioManager singleton = new RadioManager();
	private IList cops = new ArrayList ();
	private IDictionary detections = new SortedList();
	private DetectMetadata latestDetection;

	private RadioManager() {
	}

	public static RadioManager Singleton {
		get 
		{
			if(singleton == null) {
				singleton = new RadioManager();
			}

			return singleton;
		}
	}

	public void Listen(RadioElement copRadio) {
		//Debug.Log ("Listening");
		cops.Add (copRadio);
	}

	public void RadioMessage(string sender, string messageName, object value) {
		for(int i=0; i<cops.Count; i++) {
			RadioElement element = (RadioElement) cops[i];
			element.ReceiveMessage(sender, messageName, value);
		}
	}

	public bool HasPlayerBeenSpottedHere(Vector3 position, float timeRange = 25.0f) {
		return false;
	}

	public void RadioDispatcher(AI cop, Transform player, float detectTime) {
		Debug.Log ("cop = " + cop.Body.name);
		Debug.Log ("player position = " + player.position);
		Debug.Log ("detectTime = " + detectTime);
		detections.Add (detectTime.ToString (), new DetectMetadata (cop.Body.name, player.position, detectTime));
	}
	/*
	public DetectMetadata GetLastDetection() {
		int count = GetNumberOfDetections ();
		if (count > 0) {
			return detections[count-1];
		} 

		return null;
	}

*/
	public int GetNumberOfDetections() {
		return detections.Count;
	}

	public class DetectMetadata {
		string _copName;
		Vector3 _lastPosition;
		float _lastDetectTimeAtPosition;

		public DetectMetadata(string copName, Vector3 lastPosition, float lastDetectTimeAtPosition) {
			_copName = copName;
			_lastPosition = lastPosition;
			_lastDetectTimeAtPosition = lastDetectTimeAtPosition;
		}

		public Vector3 LastPosition {
			get { return _lastPosition; }
		}

		public float LastDetectTime {
			get { return _lastDetectTimeAtPosition; }
		}
	}
}
