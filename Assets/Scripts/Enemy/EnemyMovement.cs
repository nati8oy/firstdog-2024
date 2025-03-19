using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float idleTime = 2f;
    private int currentPointIndex = 0;
    private bool isIdle = false;
    private bool isChasing = false;
    private NavMeshAgent agent;
    public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[0].position);
            StartCoroutine(Patrol());
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            if (!isIdle && !isChasing && patrolPoints.Length > 1)
            {
                Transform targetPoint = patrolPoints[currentPointIndex];
                agent.SetDestination(targetPoint.position);
                while (agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return null;
                }

                isIdle = true;
                yield return new WaitForSeconds(idleTime);
                isIdle = false;

                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            }
            else
            {
                yield return null;
            }
        }
    }

    public void StartChase(Transform target)
    {
        player = target;
        isChasing = true;
        StopAllCoroutines();
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer()
    {
        while (isChasing)
        {
            if (player != null)
            {
                agent.SetDestination(player.position);
            }
            yield return null;
        }
    }

    public void StopChase()
    {
        isChasing = false;
        StartCoroutine(Patrol());
    }
}