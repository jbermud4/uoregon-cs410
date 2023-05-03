using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript: MonoBehaviour
{
    public Transform movePositionTransform;
    public int maxHitPoints = 1;
    private int hitPoints;
    private NavMeshAgent myNavMeshAgent;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
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
