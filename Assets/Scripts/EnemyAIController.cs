using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour 
{
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Transform player;
	[SerializeField] private LayerMask mask;
	[SerializeField] private Transform patrolRouteParent;
	[SerializeField] private List<Transform> patrolRoute = new List<Transform>();
	[SerializeField] private Transform test;

	private int patrolRouteIndex;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;

		SetupPatrolRoute();
		StartCoroutine(followRoute());
		
		// TEST
		Vector3 avg = Vector3.zero;
		for(int i = 0; i < patrolRoute.Count; i++)
		{
			avg += patrolRoute[i].position;
		}
		avg /= patrolRoute.Count;
		print(avg);
		test.position = avg;
	} 

	private void Update()
	{
		Debug.DrawRay(transform.position, transform.forward * 5, Color.blue);
		
		
		if(!Physics.Linecast(transform.position, player.position, mask))
		{
			if(Vector3.Angle(transform.forward, player.transform.position) < 60)
			{
				StopCoroutine(followRoute());
				agent.SetDestination(player.position);
			}
		}
	}

	private void SetupPatrolRoute()
	{
		for(int i = 0; i < patrolRouteParent.childCount; i++)
		{
			patrolRoute.Add(patrolRouteParent.GetChild(i));
		}
	}

	private IEnumerator followRoute()
	{
		agent.SetDestination(patrolRoute[0].position);

		while(true)
		{
			agent.SetDestination(patrolRoute[patrolRouteIndex].position);

			while(Vector3.Distance(agent.destination, transform.position) > 3)
			{
				yield return null;
			}

			patrolRouteIndex++;
			if(patrolRouteIndex >= patrolRoute.Count)
			{
				patrolRouteIndex = 0;
			}
			yield return null;
		}
	}

	/*private IEnumerator Patrol()
	{

	}

	///*private IEnumerator Chase()
	{

	}

	private IEnumerator Search()
	{

	}*/
}
