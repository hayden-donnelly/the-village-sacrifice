using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseState : BaseState 
{
	[SerializeField] private float captureDistance;

	public override void Construct()
	{
		Debug.Log("Entering Chase State");
		motor.agent.speed = 11;
		motor.animator.SetInteger("State", 1);
		coroutine = Chase();
		StartCoroutine(coroutine);
	}

	public override void Destruct()
	{
		motor.agent.speed = 6;
		StopCoroutine(coroutine);
	}

	private IEnumerator Chase()
	{
		while(true)
		{
			motor.agent.SetDestination(motor.playerTransform.position);

			if(Vector3.Distance(transform.position, motor.playerTransform.position) <= captureDistance)
			{
				Debug.Log("GameOver");
				SceneManager.LoadScene(1);
				break;
			}

			yield return null;
		}
		yield return null;
	}

	public override void Transition()
	{
		if(!motor.DetectedPlayer())
		{
			motor.ChangeState("SearchState");
		}
	}
}
