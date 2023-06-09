using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    // This button should call "MainMenu" scene when pressed
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
