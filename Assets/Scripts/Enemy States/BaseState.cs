using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseState : MonoBehaviour 
{
	[SerializeField] protected NavMeshAgent agent;
	[SerializeField] protected EnemyAIController motor;

	protected void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		motor = GetComponent<EnemyAIController>();
	}

	public virtual void Construct()
	{

	}

	public virtual void Destruct()
	{

	}
}