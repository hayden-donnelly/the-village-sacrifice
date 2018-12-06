using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour 
{
	[SerializeField] private GameObject keyMessage;
	[SerializeField] private float messageDisplayTime;

	public void Interact()
	{
		if(!GameState.hasKey)
		{
			StartCoroutine(DisplayKeyMessage());
			GameState.hasKey = true;
			Debug.Log("Key obtained");
		}
	}

	private IEnumerator DisplayKeyMessage()
	{
		keyMessage.SetActive(true);
		yield return new WaitForSeconds(messageDisplayTime);
		keyMessage.SetActive(false);
	}
}
