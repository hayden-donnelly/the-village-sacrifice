using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour 
{
	[SerializeField] private int fieldOfView;
	[SerializeField] private LayerMask mask;
	[HideInInspector] public NavMeshAgent agent;
	[HideInInspector] public Transform player;
	private BaseState state;
	private BaseState[] availableStates;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		availableStates = GetComponents<BaseState>();
		state = GetComponent<PatrolState>();
		state.Construct();
	} 

	private void Update()
	{
		state.Transition();
	}

	public void ChangeState(string stateName)
	{
		foreach(BaseState s in availableStates)
		{
			if(s.GetType().FullName != stateName)
			{
				continue;
			}

			if(s.unlocked)
			{
				state.Destruct();
				state = s;
				state.Construct();
			}
			return;
		}

		Debug.LogWarning("New state could not be found");
	}

	public bool CanSeePlayer()
	{
		// TODO expand this to include detection by nose and distance
		if(!Physics.Linecast(transform.position, player.position, mask)
			&& Vector3.Angle(transform.forward, player.transform.position) < fieldOfView)
		{
			return true;
		}
		return false;
	}
}
