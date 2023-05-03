using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript: MonoBehaviour //I used the unity manual/documentation and https://www.youtube.com/watch?v=atCOd4o7tG4&ab_channel=CodeMonkey as references.
{
    public Transform movePositionTransform;
    public int maxHitPoints = 1;
    public int hitPoints;
    private NavMeshAgent myNavMeshAgent;
    private Vector3 startingPosition;

    // I tried using Awake and I tried using Start, neither did exactly what I wanted, which was to have them teleport to where they started when they got hit.
    void Awake()
    {
        hitPoints = maxHitPoints;
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myNavMeshAgent.destination = movePositionTransform.position;
        startingPosition = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hitPoints > 1)
        {
            hitPoints = -1;
        }
        else
        {
            gameObject.transform.position = startingPosition;
            hitPoints = maxHitPoints;
        }
    }
}
