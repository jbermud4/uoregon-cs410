using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowTracker : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
        transform.Rotate(0, 180, 0);
        transform.Rotate(90, 0, 0);
    }
}
