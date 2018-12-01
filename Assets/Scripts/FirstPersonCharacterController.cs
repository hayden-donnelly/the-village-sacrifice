using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour 
{
	[SerializeField] private float walkSpeed;
	[SerializeField] private float sensitivityX;
	[SerializeField] private float sensitivityY;
	[SerializeField] private CharacterController controller;
	[SerializeField] private Camera mainCamera;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		mainCamera = Camera.main;
	}

	private void Update()
	{
		float mouseX = Input.GetAxis("Mouse X");
		mouseX *= sensitivityX * Time.deltaTime;
		transform.Rotate(Vector3.up, mouseX);
		float mouseY = Input.GetAxis("Mouse Y");
		mouseY *= sensitivityY * Time.deltaTime;
		mainCamera.transform.Rotate(-Vector3.right, mouseY);

		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");
		Vector3 movement = new Vector3(inputX, 0, inputY);
		movement.Normalize();
		movement = transform.TransformDirection(movement);
		movement *= walkSpeed * Time.deltaTime;
		controller.Move(movement);
	}
}
