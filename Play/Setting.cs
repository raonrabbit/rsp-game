using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject slider;
    public Toggle toggle;
    void Update()
    {
        if(toggle.isOn){
            slider.SetActive(true);
        }
        else{
            slider.SetActive(false);
        }
    }
}
