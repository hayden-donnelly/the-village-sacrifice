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
		StopAllCoroutines();
	}

	private IEnumerator Chase()
	{
		while(true)
		{
			motor.agent.SetDestination(motor.player.position);
			yield return new WaitForEndOfFrame();
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
