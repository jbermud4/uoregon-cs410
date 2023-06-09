using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float radius = 0f;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, rotationSpeed * Time.deltaTime / radius);
    }
}
