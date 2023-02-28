using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    public int DestinationPoints;
    public float remDistance = 0.5f;
    public Transform Player;

    public float radius;

    void Start()
    {
        agent = GetComponent <NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextpoint();

    }

    // Update is called once per frame
    void Update()
    {
        float Searchradius = Vector3.Distance(transform.position, Player.position);

        if (!agent.pathPending && agent.remainingDistance < remDistance)
        {
            GotoNextpoint();
        }

        if(radius > Searchradius)
        {
            agent.destination = Player.position;
        }

    }

    public void GotoNextpoint()
    {
        if(patrolPoints.Length == 0)
        {
            return;
        }

        agent.destination = patrolPoints[DestinationPoints].position;
        DestinationPoints = (DestinationPoints + 1) % patrolPoints.Length;


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
