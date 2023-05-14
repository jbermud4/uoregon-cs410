using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxHeight : MonoBehaviour
{
    public float maxHeight = 5f;
    public TextMeshProUGUI HeightMessage;

    private void FixedUpdate()
    {
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
            HeightMessage.text = "Max height reached!!";
        }
        else
        {
            {
                HeightMessage.text = " ";
            }
        }
    }
}


