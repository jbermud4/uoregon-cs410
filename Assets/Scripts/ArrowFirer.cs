using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFirer : MonoBehaviour
{
    public int fireDelay; //Frames between firing
    public Transform missile;
    public GameObject projectile;
    public float delayLeft;


    void Start()
    {
        delayLeft = fireDelay;
    }
    // Update is called once per frame
    void Update()
    {
        delayLeft -= Time.deltaTime;
        if ((delayLeft <= 0) && (Physics.Raycast(transform.position, missile.position, 100f)))
        {
            Instantiate(projectile, transform.position, transform.rotation);
            delayLeft = fireDelay;
        }
    }
}
