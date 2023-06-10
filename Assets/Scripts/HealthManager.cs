using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    private float healthAmount;
    private EnemyScript myEnemyScript;
    private ArrowScript arrowScript;
    private int damage;
    public TextMeshProUGUI loseText;


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
            myEnemyScript = other.gameObject.GetComponent<EnemyScript>();
            TakeDamage(myEnemyScript.worth * 20);
            if (healthAmount <= 0){
                StartCoroutine(EndingLose());
            }
        }
        else if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            Debug.Log("TakeDamage");
            arrowScript = other.gameObject.GetComponent<ArrowScript>();
            if (arrowScript.spent == false)
            {
                damage = arrowScript.towerDamage;
                TakeDamage(damage);
                if (healthAmount <= 0)
                {
                    StartCoroutine(EndingLose());
                }
                arrowScript.spent = true;
            }
        }
    }

    IEnumerator EndingLose()
    {
        Time.timeScale = 0f;
        loseText.text = "You Lose!";
        //WinSound.Play();
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
