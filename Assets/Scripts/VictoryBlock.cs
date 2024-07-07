using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryBlock : MonoBehaviour
{
    public static bool won = false;
    public static bool enemyWon = false;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            won = true;
        }
        if(other.transform.tag == "Ai")
        {
            enemyWon=true;
        }
    }
}
