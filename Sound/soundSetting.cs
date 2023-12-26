using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class soundSetting : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider MasterAudioSlider;
    public Slider BGMAudioSlider;
    public Slider SFXAudioSlider;
    public Slider MobAudioSlider;

    public void masterAudioControl(){
        float sound = MasterAudioSlider.value;

        if(sound == -40f) masterMixer.SetFloat("MasterVolume", -80);
        else masterMixer.SetFloat("MasterVolume", sound);
    }

    public void BGMAudioControl(){
        float sound = BGMAudioSlider.value;

        if(sound == -40f) masterMixer.SetFloat("BGMVolume", -80);
        else masterMixer.SetFloat("BGMVolume", sound);
    }

    public void SFXAudioControl(){
        float sound = SFXAudioSlider.value;

        if(sound == -40f) masterMixer.SetFloat("SFXVolume", -80);
        else masterMixer.SetFloat("SFXVolume", sound);
    }

    public void MobAudioControl(){
        float sound = MobAudioSlider.value;

        if(sound == -40f) masterMixer.SetFloat("MobVolume", -80);
        else masterMixer.SetFloat("MobVolume", sound);
    }
}
