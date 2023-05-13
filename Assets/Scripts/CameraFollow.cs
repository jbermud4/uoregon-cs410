using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public float posLerp = 0.1f;
    public float rotLerp = 0.01f;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, posLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.rotation, rotLerp);
    }
}
