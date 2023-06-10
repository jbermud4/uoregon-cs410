using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public IEnumerator Shake(float duration, float magnitude){
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0f);

            float rotationAngle = Random.Range(-1f, 1f) * magnitude;
            Quaternion rotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0f, 0f, rotationAngle));
            transform.localRotation = rotation;

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;
    }
}
