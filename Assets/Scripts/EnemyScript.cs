using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript: MonoBehaviour //I used the unity manual/documentation and https://www.youtube.com/watch?v=atCOd4o7tG4&ab_channel=CodeMonkey as references.
{
    public Transform movePositionTransform;
    public int maxHitPoints = 1;
    private int hitPoints;
    public int worth;
    private NavMeshAgent myNavMeshAgent;
    private Vector3 startingPosition;
    private Missile missileScript;

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
        if (other.gameObject.tag == "Missile")
        {
            missileScript = other.gameObject.GetComponent<Missile>();
            if (hitPoints > missileScript.damage)
            {
                hitPoints -= missileScript.damage;
            }
            else
            {
                respawn();
                missileScript.Score(worth);
            }
        }
        else
        {
            respawn();
        }
    }
    void respawn()
    {
        hitPoints = maxHitPoints;
        myNavMeshAgent.Warp(startingPosition);
        myNavMeshAgent.destination = movePositionTransform.position;
    }
}