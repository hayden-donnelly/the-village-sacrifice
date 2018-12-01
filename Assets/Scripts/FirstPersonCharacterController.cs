using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour 
{
	[SerializeField] private float walkSpeed;
	[SerializeField] private float crouchSpeed;
	[SerializeField] private float sensitivityX;
	[SerializeField] private float sensitivityY;
	[SerializeField] private CharacterController controller;
	[SerializeField] private Camera mainCamera;

	private bool isCrouched;
	private float moveSpeed;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		mainCamera = Camera.main;

		moveSpeed = walkSpeed;
	}

	private void Update()
	{
		// Crouching
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			if(isCrouched)
			{
				isCrouched = false;
				moveSpeed = walkSpeed;
			}
			else
			{
				isCrouched = true;
				moveSpeed = crouchSpeed;
			}
		}

		// Rotation
		float mouseX = Input.GetAxis("Mouse X");
		mouseX *= sensitivityX * Time.deltaTime;
		transform.Rotate(Vector3.up, mouseX);
		float mouseY = Input.GetAxis("Mouse Y");
		mouseY *= sensitivityY * Time.deltaTime;
		mainCamera.transform.Rotate(-Vector3.right, mouseY);

		// Movement
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		Vector3 movement = new Vector3(inputX, 0, inputY);
		movement.Normalize();
		movement = transform.TransformDirection(movement);
		movement *= moveSpeed * Time.deltaTime;
		controller.Move(movement);
	}
}
