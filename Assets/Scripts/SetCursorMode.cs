using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorMode : MonoBehaviour 
{
	[SerializeField] private bool cursorVisible;

	private void Start()
	{
		Cursor.visible = cursorVisible;
	}
}
