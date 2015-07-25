using System;
using UnityEngine;

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
