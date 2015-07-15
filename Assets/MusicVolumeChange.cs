using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicVolumeChange : MonoBehaviour
{
	public MusicManager musicManager;
	Slider slider;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider> ();
		slider.onValueChanged.AddListener ((value) => {
			musicManager.SetMusicVolume (value);
		});
	}
}
