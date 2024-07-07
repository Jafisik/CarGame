using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderMaker : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI sensNum;
    static public float sensitivity = 3;
    public void Update()
    {
        sensNum.text = slider.value.ToString("0.00");
        sensitivity = slider.value;
    }
}
