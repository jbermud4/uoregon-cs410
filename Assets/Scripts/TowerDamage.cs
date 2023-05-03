using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerDamage : MonoBehaviour
{
    private int damageTaken;
    private EnemyScript myEnemyScript;
    public TextMeshProUGUI damageText;
    // Start is called before the first frame update
    void Start()
    {
        damageTaken = 0;
    }

    // Inspired by roll-a-ball
    private void OnTriggerEnter(Collider other) //Sometimes I take 2 damage, sometimes I take 1, I don't know why, but it works for the POC.
    {
        if(other.gameObject.tag == "Enemy")
        {
            myEnemyScript = other.gameObject.GetComponent<EnemyScript>();
            damageTaken += myEnemyScript.hitPoints;
            damageText.text = "Damage Taken: " + damageTaken.ToString();
        }
    }
}
