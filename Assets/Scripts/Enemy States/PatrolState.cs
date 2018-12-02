﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState 
{
 	[SerializeField] private List<Transform> patrolRouteParents = new List<Transform>();
	private List<List<Transform>> patrolRoutes = new List<List<Transform>>();

	protected void Start()
	{
		base.Start();

		for(int x = 0; x < patrolRouteParents.Count; x++)
		{
			List<Transform> temp = new List<Transform>();
			for(int y = 0; y < patrolRouteParents[x].childCount; y++)
			{
				temp.Add(patrolRouteParents[x].GetChild(y));
			}
			patrolRoutes.Add(temp);
		}
	}

	public override void Construct()
	{
		float minDistance = Vector3.Distance(transform.position, patrolRoutes[0][0].position);
		Vector2Int minDistID = new Vector2Int(0, 0);

		for(int x = 0; x < patrolRoutes.Count; x++)
		{
			for(int y = 0; y < patrolRoutes[x].Count; y++)
			{
				float distance = Vector3.Distance(transform.position, patrolRoutes[x][y].position);
				if(distance < minDistance)
				{
					minDistance = distance;
					minDistID = new Vector2Int(x, y);
				}
			}
		}

		StartCoroutine(Patrol(minDistID.x, minDistID.y));
	}

	private IEnumerator Patrol(int x, int y)
	{
		int patrolRouteIndex = y;

		while(true)
		{
			agent.SetDestination(patrolRoutes[x][patrolRouteIndex].position);

			while(Vector3.Distance(transform.position, agent.destination) > 2)
			{
				yield return null;
			}

			patrolRouteIndex++;
			if(patrolRouteIndex >= patrolRoutes[x].Count)
			{
				patrolRouteIndex = 0;
			}
			yield return null;
		}
	}
}
