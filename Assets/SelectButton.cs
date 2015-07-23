using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectButton : MonoBehaviour
{
	public Button selectButton;
	public EventSystem eventSystem;

	// Use this for initialization
	void Start ()
	{
		if (eventSystem == null) {
			eventSystem = GameObject.Find ("EventSystem").GetComponent<EventSystem> ();
		}
		eventSystem.SetSelectedGameObject (selectButton.gameObject);
	}
}
