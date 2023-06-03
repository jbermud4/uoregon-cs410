using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Referenced from here https://www.youtube.com/watch?v=fD0TW6WKYQ4&t=827s

public class ShopManager : MonoBehaviour
{
    public int currentMissileIndex;
    public GameObject[] missileModels;
    public MissileBlueprint[] missiles;
    public Button buyButton;
    public TextMeshProUGUI coinText; 

void Start()
{
    foreach (MissileBlueprint missile in missiles)
    {
        if (missile.price == 0)
        {
            missile.isUnlocked = true;
        }
        else
        {
            missile.isUnlocked = PlayerPrefs.GetInt(missile.name, 0) >= 1;
        }
    }

    currentMissileIndex = PlayerPrefs.GetInt("SelectedMissile", 0);
    foreach (GameObject missile in missileModels)
    {
        missile.SetActive(false);
    }

    missileModels[currentMissileIndex].SetActive(true);

    if (missiles.Length >= 2)
    {
        missiles[1].isUnlocked = false;
        PlayerPrefs.SetInt(missiles[1].name, 0);
    }
}



  public void ChangeNext()
{
    missileModels[currentMissileIndex].SetActive(false);

    currentMissileIndex--;
    if (currentMissileIndex < 0)
    {
        currentMissileIndex = missileModels.Length - 1;
    }

    missileModels[currentMissileIndex].SetActive(true);

    MissileBlueprint m = missiles[currentMissileIndex];
    if(!m.isUnlocked)
    {
        return;
    }

    PlayerPrefs.SetInt("SelectedMissile", currentMissileIndex);
}

    public void ChangePrevious()
    {
        missileModels[currentMissileIndex].SetActive(false);

        currentMissileIndex--;
        if (currentMissileIndex < 0)
        {
        currentMissileIndex = missileModels.Length - 1;
        }

        missileModels[currentMissileIndex].SetActive(true);
        
        MissileBlueprint m = missiles[currentMissileIndex];
        if(!m.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectedMissile", currentMissileIndex);
    }

private void UpdateUI()
{
    MissileBlueprint m = missiles[currentMissileIndex];
    if (m.isUnlocked)
    {
        buyButton.gameObject.SetActive(false);
    }
    else
    {
        buyButton.gameObject.SetActive(true);
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + m.price;

        int numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0); // Retrieve the number of coins from PlayerPrefs
        coinText.text = "Coins: " + numberOfCoins.ToString(); // Update the coin text with the retrieved value

        if (m.price < numberOfCoins)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }
}

    void Update()
    {
        UpdateUI();
    }

    public void UnlockMissile()
    {
        MissileBlueprint m = missiles[currentMissileIndex];
        PlayerPrefs.SetInt(m.name, 1);
        PlayerPrefs.SetInt("SelectedMissile", currentMissileIndex);
        m.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - m.price);
    }

    


}