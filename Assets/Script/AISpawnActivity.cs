using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISpawnActivity : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    public int DestinationPoints = 0;
    public float remDistance = 0.5f;

    public static int score;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextpoint();

    }

    // Update is called once per frame
    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < remDistance)
        {
            GotoNextpoint();
        }



    }

    public void GotoNextpoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        if (DestinationPoints == patrolPoints.Length)
        {

            agent.destination = transform.position;
            agent.isStopped = true;

            score += 1;

            Destroy(gameObject);

            return;
        }

        agent.destination = patrolPoints[DestinationPoints].position;
        DestinationPoints = DestinationPoints + 1;


    }


}
