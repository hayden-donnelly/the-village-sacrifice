using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour 
{
	private bool doorUnlocked;
	public void Interact()
	{
		if(GameState.hasKey && !doorUnlocked)
		{
			Debug.Log("Level complete");
			doorUnlocked = true;
			GameState.currentSceneID++;
			SceneManager.LoadScene(GameState.currentSceneID);
		}
	}
}
