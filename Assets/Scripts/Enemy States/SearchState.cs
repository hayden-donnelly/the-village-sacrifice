using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState 
{
    [SerializeField] private float searchRadius;

    public override void Construct()
    {
        coroutine = Search();
        StartCoroutine(coroutine);
    }

    public override void Destruct()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator Search()
    {
        List<Vector3> searchRoute = GenerateSearchRoute(motor.agent.destination);
        int searchRouteIndex = 0;
        while(true)
        {
            motor.agent.SetDestination(searchRoute[searchRouteIndex]);
            while(Vector3.Distance(transform.position, motor.agent.destination) > 2)
            {
                yield return null;
            }
            
            searchRouteIndex++;
            if(searchRouteIndex >= searchRoute.Count)
            {
                motor.ChangeState("PatrolState");  
                break;  // TODO may not be needed  
            }
            yield return null;
        }
        yield return null;
    }

    private List<Vector3> GenerateSearchRoute(Vector3 lastSeenPosition)
    {
        List<Vector3> searchRoute = new List<Vector3>();
        searchRoute.Add(lastSeenPosition);

        /*int numberOfNodes = 3;
        
        for(int i = 0 ; i < numberOfNodes; i++)
        {
            float minX = lastSeenPosition.x - searchRadius;
            float maxX = lastSeenPosition.x + searchRadius;
            float minY = lastSeenPosition.y - searchRadius;
            float maxY = lastSeenPosition.y + searchRadius;

            for(int x = 0; x < 1;)
            {
                Vector3 searchNode = new Vector3(Random.Range(minX, maxX), 
                                            motor.transform.position.y, 
                                            Random.Range(minY, maxY));
                
            }
        }*/

        return searchRoute;
    }

    public override void Transition()
    {
        if(motor.CanSeePlayer())
        {
            motor.ChangeState("ChaseState");
        }
    }
}
