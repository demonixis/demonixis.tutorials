using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour 
{
	private void Start () 
	{
		var hello = Translation.Get("Hello");
		Debug.Log(hello);
	}
}
