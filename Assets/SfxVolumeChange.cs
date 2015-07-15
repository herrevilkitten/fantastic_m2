﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SfxVolumeChange : MonoBehaviour
{
	public SfxManager musicManager;
	Slider slider;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider> ();
		slider.onValueChanged.AddListener ((value) => {
			musicManager.SetSfxVolume (value);
		});
	}
}