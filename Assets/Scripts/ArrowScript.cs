using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float velocityStrength;
    public int missileDamage;
    public int towerDamage;
    public float innaccuracyPossible;
    //public Transform missileTransform;
    public GameObject missile;
    private float innaccuracyX;
    private float innaccuracyY;
    private float innaccuracyZ;
    private Missile missileScript;
    private HealthManager towerScript;
    private Rigidbody myRigidBody;
    public bool spent = false;

    void Awake()
    {
        Destroy(gameObject, 45f); //Destroy self within 45s even if it doesn't hit anything.
        myRigidBody = GetComponent<Rigidbody>();
        missile = GameObject.Find("Missile");

        //transform.Rotate(0, 180, 0);
        //transform.Rotate(90, 0, 0);

        innaccuracyX = Random.Range(-innaccuracyPossible, innaccuracyPossible);
        innaccuracyY = Random.Range(-innaccuracyPossible, innaccuracyPossible);
        innaccuracyZ = Random.Range(-innaccuracyPossible, innaccuracyPossible);
        transform.LookAt(missile.transform);
        transform.Rotate(innaccuracyX, innaccuracyY, innaccuracyZ, Space.Self);

        //These two lines taken from the Missile script. Then slightly modified.
        Vector3 force = transform.forward * velocityStrength;
        myRigidBody.velocity = force;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(GetComponent<CapsuleCollider>());
        spent = true;
        Destroy(gameObject, 5f);
        //myRigidBody.useGravity = true; Would be cool to have them fall to the ground, but this just makes them fall through the floor.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Missile" && (spent == false))
        {
            missileScript = other.gameObject.GetComponent<Missile>();
            missileScript.health -= missileDamage;
            if (missileScript.health <= 0)
            {
                missileScript.collisionExplosion.Play();
                missileScript.respawn();
            }
        }
        //else
        //{
        //    towerScript = other.gameObject.GetComponent<HealthManager>();
        //    towerScript.
        //}
        //Destroy(GetComponent<CapsuleCollider>());
        spent = true;
        Destroy(gameObject, 5f);
        //myRigidBody.useGravity = true;
    }
}
