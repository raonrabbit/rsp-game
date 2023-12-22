using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetSpeed : MonoBehaviour
{
    public readonly float[] SpeedData = {0f, 0.25f, 1f, 1.75f};
    public Text countText;
    public float current_speed;
    public Toggle[] speedToggles;

    void Awake()
    {
        current_speed = PlayerPrefs.GetFloat("Speed");
        if(current_speed == SpeedData[0]){
            speedToggles[0].isOn = true;
        }
        else if(current_speed == SpeedData[1]){
            speedToggles[1].isOn = true;
        }
        else if(current_speed == SpeedData[2]){
            speedToggles[2].isOn = true;
        }
        else if(current_speed == SpeedData[3]){
            speedToggles[3].isOn = true;
        }
    }

    void Update(){
        if(PlayerPrefs.GetFloat("Speed") == 0f) Time.timeScale = 0;
    }

    public void OnChangedStopSpeed()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetFloat("Speed", SpeedData[0]);
    }

    public void OnChangedNormalSpeed()
    {
        if(StartSetter.instance.isStart)
            Time.timeScale = 1;
        PlayerPrefs.SetFloat("Speed", SpeedData[1]);
    }

    public void OnChangedFastSpeed()
    {
        if(StartSetter.instance.isStart)
            Time.timeScale = 1;
        PlayerPrefs.SetFloat("Speed", SpeedData[2]);
    }

    public void OnChangedSuperFastSpeed()
    {
        if(StartSetter.instance.isStart)
            Time.timeScale = 1;
        PlayerPrefs.SetFloat("Speed", SpeedData[3]);
    }
}
