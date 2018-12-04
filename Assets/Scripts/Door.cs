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
			print(SceneManager.sceneCount);
			if(GameState.currentSceneID > 4)
			{
				SceneManager.LoadScene(0);
				return;
			}
			SceneManager.LoadScene(GameState.currentSceneID);
		}
	}
}
