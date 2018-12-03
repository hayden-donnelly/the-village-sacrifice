using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	public void Interact()
	{
		if(GameState.hasKey)
		{
			Debug.Log("Level complete");
			// Load next level
		}
	}
}
