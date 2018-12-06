using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour 
{
	[SerializeField] private GameObject keyMessage;
	[SerializeField] private float messageDisplayTime;
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
		else
		{
			StartCoroutine(DisplayKeyMessage());
		}
	}

	private IEnumerator DisplayKeyMessage()
	{
		keyMessage.SetActive(true);
		yield return new WaitForSeconds(messageDisplayTime);
		keyMessage.SetActive(false);
	}
}
