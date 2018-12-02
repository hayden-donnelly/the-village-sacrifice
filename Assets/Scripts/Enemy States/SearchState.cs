using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState 
{
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
        List<Transform> searchRoute = GenerateSearchRoute();
        int searchRouteIndex = 0;
        while(true)
        {
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

    private List<Transform> GenerateSearchRoute()
    {
        List<Transform> searchRoute = new List<Transform>();
        // Generate route
        return searchRoute;
    }
}
