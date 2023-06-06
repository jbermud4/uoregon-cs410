using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=-GWjA6dixV4&ab_channel=BMo as credit for main menu stuff.

public class LevelSelect : MonoBehaviour
{
    public void loadLevelOne()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void loadLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
    public void loadLevelThree()
    {
        SceneManager.LoadScene("Level3-Moon");
    }
}
