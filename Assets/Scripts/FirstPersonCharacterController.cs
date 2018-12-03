using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour 
{
	[SerializeField] private float walkSpeed;
	[SerializeField] private float crouchSpeed;
	[SerializeField] private float gravityForce;
	[SerializeField] private float sensitivityX;
	[SerializeField] private float sensitivityY;
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Transform head;
	[HideInInspector] public CharacterController Controller;
	[HideInInspector] public bool isCrouched;
	private float moveSpeed;

	private void Start()
	{
		Controller = GetComponent<CharacterController>();
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
		movement *= moveSpeed;
		movement = new Vector3(movement.x, gravityForce, movement.z);
		movement *= Time.deltaTime;

		Controller.Move(movement);
	}
}
