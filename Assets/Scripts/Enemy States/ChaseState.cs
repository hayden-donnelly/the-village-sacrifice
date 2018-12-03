using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState 
{
	[SerializeField] private float captureDistance;

	public override void Construct()
	{
		Debug.Log("Entering Chase State");
		motor.animator.SetInteger("State", 1);
		coroutine = Chase();
		StartCoroutine(coroutine);
	}

	public override void Destruct()
	{
		StopCoroutine(coroutine);
	}

	private IEnumerator Chase()
	{
		while(true)
		{
			motor.agent.SetDestination(motor.playerTransform.position);

			if(Vector3.Distance(transform.position, motor.playerTransform.position) <= captureDistance)
			{
				// Gameover
			}

			yield return null;
		}
	}

	public override void Transition()
	{
		if(!motor.DetectedPlayer())
		{
			motor.ChangeState("SearchState");
		}
	}
}
