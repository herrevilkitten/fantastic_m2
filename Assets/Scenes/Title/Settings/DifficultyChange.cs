using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyChange : MonoBehaviour
{
	public Text difficultyTitle;
	Slider slider;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider> ();
		slider.onValueChanged.AddListener ((value) => {
			string text = "Difficulty: ";
			switch ((int)value) {
			case 1:
				text += "Easy";
				break;
			case 2:
				text += "Normal";
				break;
			case 3:
				text += "Hard";
				break;
			}
			difficultyTitle.text = text;
		});
	}
}
