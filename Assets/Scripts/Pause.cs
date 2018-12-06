using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
	private bool paused;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(paused)
			{
				paused = false;
				Time.timeScale = 1;
			}
			else
			{
				paused = true;
				Time.timeScale = 0;
			}
		}
	}
}
