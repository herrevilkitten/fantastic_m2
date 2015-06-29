using UnityEngine;
using System.Collections;

public class PreventObjectDestrution : MonoBehaviour
{
	void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
	}
}
