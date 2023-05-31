using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    // Update is called once per frame
    void Update()
    {
        // Sample code to test taking damage and healing
        if(Input.GetKeyDown(KeyCode.N)){
            TakeDamage(10);
        }

        if(Input.GetKeyDown(KeyCode.M)){
            Heal(10);
        }
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
}
