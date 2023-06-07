using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    private float healthAmount;
    //private EnemyScript myEnemyScript;


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

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
            //myEnemyScript = other.gameObject.GetComponent<EnemyScript>();
            
            TakeDamage(25);
            if (healthAmount <= 0){
                SceneManager.LoadScene("Main Menu");
            }
        }
    }


}
