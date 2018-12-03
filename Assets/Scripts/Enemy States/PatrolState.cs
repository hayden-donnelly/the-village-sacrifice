using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState 
{
	[Tooltip("Out of 100")]
	[SerializeField] private float chanceToChangePatolRoutes;

 	[SerializeField] private List<Transform> patrolRouteParents = new List<Transform>();
	private List<List<Vector3>> patrolRoutes = new List<List<Vector3>>();
	private List<Vector3> patrolRouteCentres = new List<Vector3>();

	private void Awake()
	{
		base.Awake();

		// Populate patrolRoutes
		for(int x = 0; x < patrolRouteParents.Count; x++)
		{
			List<Vector3> temp = new List<Vector3>();
			for(int y = 0; y < patrolRouteParents[x].childCount; y++)
			{
				temp.Add(patrolRouteParents[x].GetChild(y).position);
			}
			patrolRoutes.Add(temp);
		}

		// Populate patrolRouteCentres
		for(int x = 0; x < patrolRoutes.Count; x++)
		{
			Vector3 centrePoint = Vector3.zero;
			for(int y = 0; y < patrolRoutes[x].Count; y++)
			{
				centrePoint += patrolRoutes[x][y];
			}
			centrePoint /= patrolRoutes[x].Count;
			patrolRouteCentres.Add(centrePoint);
		}
	}

	public override void Construct()
	{
		Debug.Log("Entering Patrol State");

		float minDistance = Vector3.Distance(transform.position, patrolRoutes[0][0]);
		Vector2Int minDistID = new Vector2Int(0, 0);

		for(int x = 0; x < patrolRoutes.Count; x++)
		{
			for(int y = 0; y < patrolRoutes[x].Count; y++)
			{
				float distance = Vector3.Distance(transform.position, patrolRoutes[x][y]);
				if(distance < minDistance)
				{
					minDistance = distance;
					minDistID = new Vector2Int(x, y);
				}
			}
		}

		coroutine = Patrol(minDistID.x, minDistID.y);
		StartCoroutine(coroutine);
	}

	public override void Destruct()
	{
		StopCoroutine(coroutine);
	}

	private IEnumerator Patrol(int x, int y)
	{
		int patrolRouteIndex = y;
		int timesPatrolledCurrentRoute = 0;

		while(true)
		{
			// Follow patrol route
			motor.agent.SetDestination(patrolRoutes[x][patrolRouteIndex]);

			while(Vector3.Distance(transform.position, motor.agent.destination) > 2)
			{
				yield return null;
			}

			patrolRouteIndex++;
			if(patrolRouteIndex >= patrolRoutes[x].Count)
			{
				patrolRouteIndex = 0;
				timesPatrolledCurrentRoute++;
				Debug.Log("Chance to change routes: " + chanceToChangePatolRoutes * timesPatrolledCurrentRoute + "/100");
				if(Random.Range(0, 100) < (chanceToChangePatolRoutes * timesPatrolledCurrentRoute))
				{
					Debug.Log("Changing routes");
					timesPatrolledCurrentRoute = 0;
					x = FindPatrolRouteClosestToPLayer();
				}
			}
			yield return null;
		}
	}

	private int FindPatrolRouteClosestToPLayer()
	{
		float minDistance = Vector3.Distance(patrolRouteCentres[0], motor.playerTransform.position);
		int minDistID = 0;

		for(int i = 0; i < patrolRouteCentres.Count; i++)
		{
			float distance = Vector3.Distance(patrolRouteCentres[i], motor.playerTransform.position);
			if(distance < minDistance)
			{
				minDistance = distance;
				minDistID = i;
			}
		}

		return minDistID;
	}

	public override void Transition()
	{
		if(motor.DetectedPlayer())
		{
			motor.ChangeState("ChaseState");
		}
	}
}

