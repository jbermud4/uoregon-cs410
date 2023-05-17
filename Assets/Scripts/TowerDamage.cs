using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TowerDamage : MonoBehaviour
{
    public int maxHealth;
    private int Health;
    //private int damageTaken;
    private EnemyScript myEnemyScript;
    public TextMeshProUGUI damageText;
    // Start is called before the first frame update
    void Start()
    {
        //damageTaken = 0;
        Health = maxHealth;
        damageText.text = "Health: " + Health.ToString() + "/" + maxHealth.ToString();
    }

    // Inspired by roll-a-ball
    private void OnTriggerEnter(Collider other) //Sometimes I take 2 damage, sometimes I take 1, I don't know why, but it works for the POC.
    {
        if(other.gameObject.tag == "Enemy")
        {
            myEnemyScript = other.gameObject.GetComponent<EnemyScript>();
            Health -= myEnemyScript.hitPoints;
            damageText.text = "Health: " + Health.ToString() + "/" + maxHealth.ToString();
            if (Health <= 0)
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
