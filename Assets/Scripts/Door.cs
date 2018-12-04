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
			print(GameState.currentSceneID);
			GameState.currentSceneID++;
			if(GameState.currentSceneID < SceneManager.sceneCount)
			{
				// load victory scene
				return;
			}
			SceneManager.LoadScene(GameState.currentSceneID);
		}
	}
}
