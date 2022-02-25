using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		Application.Quit();
	}
}
