using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuScript : MonoBehaviour
{
    public static bool cursorLock = false;
    public void OnStartClick()
    {
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
    }

    public void OnLevel1Clicked()
    {
        cursorLock = true;
        SceneManager.LoadScene("Level1");
        SceneManager.UnloadSceneAsync("Menu");
        OnBackClick();
    }

    public void OnLevel2Clicked()
    {
        cursorLock = true;
        SceneManager.LoadScene("Level2");
        SceneManager.UnloadSceneAsync("Menu");
        OnBackClick();
    }

    public void OnSettingsClick()
    {
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
    }

    public void OnBackClick()
    {
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
    }
    public void Update()
    {
        if (cursorLock)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
