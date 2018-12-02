using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState 
{
	public override void Construct()
	{
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
			yield return null;
		}
	}

	public override void Transition()
	{
		if(!motor.CanSeePlayer())
		{
			motor.ChangeState("PatrolState");
		}
	}
}
