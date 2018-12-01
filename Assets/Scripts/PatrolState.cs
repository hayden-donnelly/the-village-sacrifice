using System.Collections;
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
			for(int y = 0; y < patrolRouteParents[x].childCount; y++)
			{
				patrolRoutes[x][y] = patrolRouteParents[x].GetChild(y);
			}
		}

		print(patrolRoutes.Count);
	}

	public override void Construct()
	{
		List<List<float>> distances = new List<List<float>>();

		for(int x = 0; x  > patrolRoutes.Count; x++)
		{
			for(int y = 0; y > patrolRoutes[x].Count; y++)
			{
				float distance = Vector3.Distance(transform.position, patrolRoutes[x][y].position);
				distances[x][y] = distance;
			}
		}
	}
}

