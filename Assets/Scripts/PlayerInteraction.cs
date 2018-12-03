using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour 
{
	[SerializeField] private GameObject interactionPrompt;
	private bool canInteract;
	private GameObject interactableObject;

	private void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Interactable")
		{
			interactionPrompt.SetActive(true);
			canInteract = true;
			interactableObject = col.transform.gameObject;
		}
	}

	private void OnTriggerExit(Collider col)
	{
		if(col.tag == "Interactable")
		{
			interactionPrompt.SetActive(false);
			canInteract = false;
		}
	}

	private void Update()
	{
		if(canInteract && Input.GetKeyDown(KeyCode.E))
		{
			interactableObject.SendMessage("Interact");
		}
	}
}
