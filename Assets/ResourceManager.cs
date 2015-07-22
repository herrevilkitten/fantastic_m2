using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour
{
	public Shader hightlightShader;

	public static ResourceManager instance;

	// Use this for initialization
	void Start ()
	{
		ResourceManager.instance = this;
	}
}
