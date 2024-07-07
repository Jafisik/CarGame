using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI VictoryText;
    public TextMeshProUGUI speed;
    public bool playing;
    private float timer;
    private bool lost = false;
    void Update()
    {
        if (playing == true)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
            if(VictoryBlock.enemyWon == true && VictoryBlock.won == false)
            {
                VictoryText.text = "Enemy won";
                lost = true;
            }
            if(VictoryBlock.won == false)
            {
                TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
                
            } else
            {
                if(VictoryBlock.enemyWon == false)
                {
                    VictoryText.text = "You won";
                }
                
            }
            
        }
    }
}
