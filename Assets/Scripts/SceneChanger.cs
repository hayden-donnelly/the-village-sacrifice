using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour 
{
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha0))
		{
			SceneManager.LoadScene(2);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SceneManager.LoadScene(3);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			SceneManager.LoadScene(4);
		}
	}
}
