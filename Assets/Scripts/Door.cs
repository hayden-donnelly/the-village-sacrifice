using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	public void Interact()
	{
		if(GameState.hasKey)
		{
			print("Level complete");
		}
		else
		{
			print("Get the key");
		}
	}
}
