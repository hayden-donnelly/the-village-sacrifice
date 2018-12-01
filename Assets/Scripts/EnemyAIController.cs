using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour 
{
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Transform player;
	[SerializeField] private LayerMask mask;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	} 

	private void Update()
	{
		Debug.DrawRay(transform.position, transform.forward * 5, Color.blue);
		
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	agent.SetDestination(player.position);
		//}

		if(!Physics.Linecast(transform.position, player.position, mask))
		{
			if(Vector3.Angle(transform.forward, player.transform.position) < 120)
			{
				agent.SetDestination(player.position);
			}
		}
	}
}
