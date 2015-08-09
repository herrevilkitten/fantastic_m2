using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QualityChange : MonoBehaviour
{
	public Text label;
	Slider slider;
	string[] qualityNames;

	// Use this for initialization
	void Awake ()
	{
		slider = GetComponent<Slider> ();

		qualityNames = QualitySettings.names;
		slider.minValue = 0;
		slider.maxValue = qualityNames.Length - 1;
		slider.value = Mathf.Clamp (PlayerPrefs.GetInt ("Quality"), slider.minValue, slider.maxValue);
		label.text = qualityNames [(int)slider.value];
	}
	
	void Update ()
	{
		slider.onValueChanged.AddListener ((newValue) => {
			int value = (int)newValue;
			QualitySettings.SetQualityLevel (value);
			label.text = qualityNames [value];
		});
	}
}
