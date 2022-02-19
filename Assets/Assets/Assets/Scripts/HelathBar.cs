using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HelathBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;

    public void setHelath(int helath){
        slider.value = helath;
    }

    public void setMaxHelath(int helath){
        slider.maxValue = helath;
        slider.value = helath;
    }

}
