using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float velocityStrength;
    public int missileDamage;
    public int towerDamage;
    public float innaccuracyPossible;
    //public Transform missile;
    private float innaccuracyX;
    private float innaccuracyY;
    private float innaccuracyZ;
    private Missile missileScript;
    private HealthManager towerScript;

    void Awake()
    {
        innaccuracyX = Random.Range(-innaccuracyPossible, innaccuracyPossible);
        innaccuracyY = Random.Range(-innaccuracyPossible, innaccuracyPossible);
        innaccuracyZ = Random.Range(-innaccuracyPossible, innaccuracyPossible);
        //transform.LookAt(missile);
        transform.Rotate(innaccuracyX, innaccuracyY, innaccuracyZ, Space.Self);

        //These two lines taken from the Missile script.
        Vector3 force = transform.forward * velocityStrength;
        GetComponent<Rigidbody>().AddForce(force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GetComponent<CapsuleCollider>());
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Missile")
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
        Destroy(GetComponent<CapsuleCollider>());
        Destroy(gameObject, 5f);
    }
}