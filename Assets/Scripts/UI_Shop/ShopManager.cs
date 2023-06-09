using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int currentMissileIndex;
    public GameObject[] missileModels;

    void Start()
    {
        currentMissileIndex = PlayerPrefs.GetInt("SelectedMissile", 0);
        foreach(GameObject missile in missileModels)
            missile.SetActive(false);
        
        missileModels[currentMissileIndex].SetActive(true);
    }


    public void ChangeNext()
    {
        missileModels[currentMissileIndex].SetActive(false);
        currentMissileIndex++;

        if(currentMissileIndex == missileModels.Length)
        {
            currentMissileIndex = 0;
        }

        missileModels[currentMissileIndex].SetActive(true);
        
        PlayerPrefs.SetInt("SelectedMissile", currentMissileIndex);
    }

    public void ChangePrevious()
    {
        missileModels[currentMissileIndex].SetActive(false);
        currentMissileIndex--;

        if(currentMissileIndex == -1)
        {
            currentMissileIndex = missileModels.Length - 1;
        }

        missileModels[currentMissileIndex].SetActive(true);
        
        PlayerPrefs.SetInt("SelectedMissile", currentMissileIndex);
    }

}