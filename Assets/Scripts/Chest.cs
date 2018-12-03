using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour 
{
	public void Interact()
	{
		if(!GameState.hasKey)
		{
			GameState.hasKey = true;
			Debug.Log("Key obtained");
		}
	}
}
