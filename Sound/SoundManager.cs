using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioClip[] audio_clips;
    AudioSource BGM;
    AudioSource SFX;
    
    void Awake()
    {
        if(instance == null)
            instance = this;
        
        else if(instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public void PlaySFXSound(string type){
        int index = 0;

        switch(type){
            case "ButtonClick": index = 0; break;
            case "MenuOpen": index = 1; break;
            case "ToggleClick": index = 2; break;
            case "EatSound": index = 3; break;
        }

        SFX.clip = audio_clips[index];
        SFX.PlayOneShot(SFX.clip);
    }
}
