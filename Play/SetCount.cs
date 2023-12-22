using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCount : MonoBehaviour
{
    public Slider slider;
    public Text countText;
    void Awake()
    {
        if(PlayerPrefs.HasKey("Amout"))
        {
            slider.value = PlayerPrefs.GetInt("Amount");
        }
        //slider.value = Generator.numberOfObjects;
    }

    void Update()
    {
        //Generator.numberOfObjects = (int)slider.value;
        PlayerPrefs.SetInt("Amount", (int)slider.value);
        countText.text = (slider.value).ToString();
        GameManager.instance.Rock_count.text = slider.value.ToString();
        GameManager.instance.Scissers_count.text = slider.value.ToString();
        GameManager.instance.Paper_count.text = slider.value.ToString();
    }

    public void OnChangedValue()
    {
        GameManager.instance.Rock_count.text = slider.value.ToString();
        GameManager.instance.Scissers_count.text = slider.value.ToString();
        GameManager.instance.Paper_count.text = slider.value.ToString();
    }
}
