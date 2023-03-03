using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawnActivity : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    public int DestinationPoints = 2;
    public float remDistance = 0.5f;
    private int pointsVisited = 0;
    private float agentSpeed = 10.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.speed = agentSpeed;
        GotoNextpoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < remDistance && pointsVisited < patrolPoints.Length)
        {
            GotoNextpoint();
        }
    }

    public void GotoNextpoint()
    {
        if (patrolPoints.Length == 0 || pointsVisited >= patrolPoints.Length)
        {
            agent.isStopped = true;
            return;
        }

        agent.destination = patrolPoints[DestinationPoints].position;
        DestinationPoints = (DestinationPoints + 1) % patrolPoints.Length;
        pointsVisited++;
    }
}


