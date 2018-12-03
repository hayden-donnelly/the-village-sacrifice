using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour 
{
	public Animator animator;
	[SerializeField] private int fieldOfView;
	[SerializeField] private float sightDetectionDistance;
	[SerializeField] private float walkingDetectionRadius;
	[SerializeField] private float crouchingDetectionRadius;
	[SerializeField] private LayerMask mask;
	[SerializeField] private Transform head;
	[HideInInspector] public NavMeshAgent agent;
	[HideInInspector] public Transform playerTransform;
	[HideInInspector] public FirstPersonCharacterController player;
	private BaseState state;
	private BaseState[] availableStates;

	public enum AnimStates
	{
		Walk = 1,
		Notice = 2,
		Search = 3,
	}

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();

		GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
		playerTransform = playerObj.transform;
		player = playerObj.GetComponent<FirstPersonCharacterController>();
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

	public bool DetectedPlayer()
	{
		if(!Physics.Linecast(head.position, playerTransform.position, mask))
		{
			if(Vector3.Angle(transform.forward, playerTransform.transform.position) < fieldOfView
				&& Vector3.Distance(transform.position, playerTransform.position) <= sightDetectionDistance)
			{
				return true;
			}
			if(player.isCrouched)
			{
				if(Vector3.Distance(transform.position, playerTransform.position) <= crouchingDetectionRadius)
				{
					return true;
				}
			}
			else
			{
				if(Vector3.Distance(transform.position, playerTransform.position) <= walkingDetectionRadius)
				{
					return true;
				}
			}
		}
		return false;
	}
}
