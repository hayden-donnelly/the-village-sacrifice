using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState 
{
    [SerializeField] private float searchDistance;

    public override void Construct()
    {
        Debug.Log("Entering Search State");
        motor.animator.SetInteger("State", 1);
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
            // Follow search route
            motor.agent.SetDestination(searchRoute[searchRouteIndex]);
            while(Vector3.Distance(transform.position, motor.agent.destination) > 2)
            {
                yield return null;
            }
            
            searchRouteIndex++;
            if(searchRouteIndex >= searchRoute.Count)
            {
                StartCoroutine(ExitToPatrol());
                break;
            }
            yield return null;
        }
        yield return null;
    }

    private IEnumerator ExitToPatrol()
    {
        motor.animator.SetInteger("State", 3);  
        yield return new WaitForSeconds(3);
        motor.animator.SetInteger("State", 1);
        motor.ChangeState("PatrolState");  
    }

    private List<Vector3> GenerateSearchRoute(Vector3 lastSeenPosition)
    {   
        // Predict the position that the player will move to
        Vector3 playerMovement = motor.player.Controller.velocity;
        playerMovement = new Vector3(playerMovement.x, 0, playerMovement.z);
        playerMovement.Normalize();
        playerMovement *= searchDistance;
        Vector3 predictedPlayerPosition = lastSeenPosition + playerMovement;

        List<Vector3> searchRoute = new List<Vector3>();
        searchRoute.Add(lastSeenPosition);
        searchRoute.Add(predictedPlayerPosition);
        searchRoute.Add(predictedPlayerPosition + (Vector3.right * 10));
        searchRoute.Add(predictedPlayerPosition + (Vector3.right * -10));
        searchRoute.Add(predictedPlayerPosition + (Vector3.forward * 10));
        searchRoute.Add(predictedPlayerPosition + (Vector3.forward * -10));

        return searchRoute;
    }

    public override void Transition()
    {
        if(motor.DetectedPlayer())
        {
            motor.ChangeState("ChaseState");
        }
    }
}
