using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissileSelector : MonoBehaviour
{
    public int currentMissileIndex;
    public GameObject[] missiles;

    void Start()
    {
        currentMissileIndex = PlayerPrefs.GetInt("SelectedMissile", 0);
        foreach(GameObject missile in missiles)
        {
            missile.SetActive(false);
        }
        
        missiles[currentMissileIndex].SetActive(true);
    
    }
}