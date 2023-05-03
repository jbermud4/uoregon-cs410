using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{

    public Transform movePositionTransform;
    private NavMeshAgent myNavMeshAgent;
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myNavMeshAgent.destination = movePositionTransform.position;
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    myNavMeshAgent.destination = movePositionTransform.position;
    //}

    private void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position = startingPosition;
    }
}
