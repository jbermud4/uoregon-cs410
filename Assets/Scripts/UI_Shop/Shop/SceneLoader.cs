using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        SceneManager.LoadScene("Shop");
    }
}
