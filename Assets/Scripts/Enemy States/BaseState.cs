using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseState : MonoBehaviour 
{
	public bool unlocked;
	protected IEnumerator coroutine;
	protected EnemyAIController motor;

	protected void Awake()
	{
		motor = GetComponent<EnemyAIController>();
	}

	public virtual void Construct()
	{

	}

	public virtual void Destruct()
	{
		
	}

	public virtual void Transition()
	{

	}
}