using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseState : MonoBehaviour 
{
	public bool unlocked;
	public bool looping;
	protected EnemyAIController motor;

	protected void Awake()
	{
		motor = GetComponent<EnemyAIController>();
	}

	public virtual void Construct()
	{
		looping = true;
	}

	public virtual void Destruct()
	{
		looping = false;
	}

	public virtual void Transition()
	{

	}
}