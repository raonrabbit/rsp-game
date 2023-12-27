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
    void Awake(){
        if(PlayerPrefs.HasKey("MasterVolume"))
            MasterAudioSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        if(PlayerPrefs.HasKey("BGMVolume"))
            BGMAudioSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        if(PlayerPrefs.HasKey("SFXVolume"))
            SFXAudioSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        if(PlayerPrefs.HasKey("MobVolume"))
            MobAudioSlider.value = PlayerPrefs.GetFloat("MobVolume");
    }

    void Start(){
        masterAudioControl();
        BGMAudioControl();
        SFXAudioControl();
        MobAudioControl();
    }
    
    public void masterAudioControl(){
        float sound = MasterAudioSlider.value;
        PlayerPrefs.SetFloat("MasterVolume", sound);
        if(sound == -40f) masterMixer.SetFloat("MasterVolume", -80);
        else masterMixer.SetFloat("MasterVolume", sound);
    }

    public void BGMAudioControl(){
        float sound = BGMAudioSlider.value;
        PlayerPrefs.SetFloat("BGMVolume", sound);
        if(sound == -40f) masterMixer.SetFloat("BGMVolume", -80);
        else masterMixer.SetFloat("BGMVolume", sound);
    }

    public void SFXAudioControl(){
        float sound = SFXAudioSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", sound);
        if(sound == -40f) masterMixer.SetFloat("SFXVolume", -80);
        else masterMixer.SetFloat("SFXVolume", sound);
    }

    public void MobAudioControl(){
        float sound = MobAudioSlider.value;
        PlayerPrefs.SetFloat("MobVolume", sound);
        if(sound == -40f) masterMixer.SetFloat("MobVolume", -80);
        else masterMixer.SetFloat("MobVolume", sound);
    }
}
