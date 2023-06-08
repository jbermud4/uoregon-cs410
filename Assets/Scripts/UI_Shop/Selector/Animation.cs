using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Vector3 initPosition;
    [SerializeField] private Vector3 finalPosition;

    private void Awake()
    {
        initPosition = transform.position;
    }

    private void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = initPosition;
    }
}


