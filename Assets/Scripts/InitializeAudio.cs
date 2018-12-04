using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeAudio : MonoBehaviour 
{
	[SerializeField] private AudioSource audioSource;
	private bool FirstTime = true;

	private void Start()
	{
		DontDestroyOnLoad(this.gameObject);

		if(GameObject.FindGameObjectsWithTag("AudioListener").Length == 1) 
		{
			audioSource.Play();
			FirstTime = false;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}