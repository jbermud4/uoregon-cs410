using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{
    public int index;
    public GameObject[] missiles;

    void Start()
    {
        index = PlayerPrefs.GetInt("missileIndex");
        GameObject missile = Instantiate(missiles[index], Vector3.zero, Quaternion.identity);
    }
}
