using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    private float healthAmount;
    //private EnemyScript myEnemyScript;
    private ArrowScript arrowScript;
    private int damage;


    void Start(){
        healthAmount = 100f;
    }

    public void TakeDamage(float damage){
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount){
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("TakeDamage");
            TakeDamage(25);
            if (healthAmount <= 0){
                SceneManager.LoadScene("Main Menu");
            }
        }
        else if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            Debug.Log("TakeDamage");
            arrowScript = other.gameObject.GetComponent<ArrowScript>();
            damage = arrowScript.towerDamage;
            TakeDamage(damage);
            if (healthAmount <= 0)
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }


}
