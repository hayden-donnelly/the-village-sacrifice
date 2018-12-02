using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState 
{
	public override void Construct()
	{
		StartCoroutine(Chase());
	}

	public override void Destruct()
	{
		StopCoroutine(Chase());
	}

	private IEnumerator Chase()
	{
		while(true)
		{
			motor.agent.SetDestination(motor.player.position);
			yield return null;
		}
		yield return null;
	}

	public override void Transition()
	{
		if(!motor.CanSeePlayer())
		{
			motor.ChangeState("PatrolState");
		}
	}
}
