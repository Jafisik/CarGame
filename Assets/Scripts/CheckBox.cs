using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    static public bool carSpeedOn;
    [SerializeField] TextMeshProUGUI text;
    public void Start()
    {
        text.text = "Off";
    }
    public void OnClickCheck()
    {
        if (carSpeedOn)
        {
            carSpeedOn = false;
            text.text = "Off";
        }
        else
        {
            carSpeedOn = true;
            text.text = "On";
        }
    }
}
