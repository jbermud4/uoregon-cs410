using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFirer : MonoBehaviour
{
    public int fireDelay; //Frames between firing
    //public Transform missile;
    public GameObject projectile;
    private GameObject clone;
    private float delayLeft;


    void Start()
    {
        delayLeft = fireDelay;
    }
    // Update is called once per frame
    void Update()
    {
        delayLeft -= Time.deltaTime;
        //if ((delayLeft <= 0) && !(Physics.Raycast(transform.position, missile.position, Vector3.Distance(transform.position, missile.position)))) Failed attempt to have line of sight
        if (delayLeft <= 0)
        {
            clone = Instantiate(projectile, transform.position, transform.rotation);
            Physics.IgnoreCollision(clone.GetComponent<CapsuleCollider>(), GetComponent<BoxCollider>());
            delayLeft = fireDelay;
        }
    }
}
