using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuScript.cursorLock = false;
            VictoryBlock.won = false;
            VictoryBlock.enemyWon = false;
            SceneManager.LoadScene("Menu");
            SceneManager.UnloadSceneAsync("Level1");
            SceneManager.UnloadSceneAsync("Level2");
        }
    }
}
