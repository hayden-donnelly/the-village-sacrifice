using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour 
{
	[SerializeField] private float walkSpeed;
	[SerializeField] private CharacterController controller;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		Vector3 movement = new Vector3(inputX, 0, inputY);
		movement.Normalize();
		movement *= walkSpeed * Time.deltaTime;
		controller.Move(movement);
	}
}
