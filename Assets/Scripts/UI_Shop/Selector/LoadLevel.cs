using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public GameObject selectedAsset;
    public GameObject userControlledObject; // Reference to the object controlled by the user

    public void loadLevelOne()
    {
        GameManager.Instance.selectedAsset = selectedAsset;
        DisableUserControlledObject();
        SceneManager.LoadScene("MainScene");
    }

    public void loadLevelTwo()
    {
        GameManager.Instance.selectedAsset = selectedAsset;
        DisableUserControlledObject();
        SceneManager.LoadScene("Level2");
    }

    public void loadLevelThree()
    {
        GameManager.Instance.selectedAsset = selectedAsset;
        DisableUserControlledObject();
        SceneManager.LoadScene("Level3-Moon");
    }

    private void DisableUserControlledObject()
    {
        if (userControlledObject != null)
        {
            userControlledObject.SetActive(false);
        }
    }
}
