using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioClip[] SFX_clips;
    public AudioClip MobSound;
    int currentPlayCount = 0;
    int maxPlayCount = 2;
    AudioSource BGM;
    AudioSource SFX;
    AudioSource MOBSOUND;
    
    void Awake()
    {
        if(instance == null)
            instance = this;
        
        else if(instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        MOBSOUND = GameObject.Find("MOBSOUND").GetComponent<AudioSource>();
    }

    public void PlaySFXSound(string type){
        int index = 0;

        switch(type){
            case "ButtonClick": index = 0; break;
            case "MenuOpen": index = 1; break;
            case "ToggleClick": index = 2; break;
        }

        SFX.clip = SFX_clips[index];
        SFX.PlayOneShot(SFX.clip);
    }

    public void PlayMobSound(){
        if(currentPlayCount > maxPlayCount) return;

        currentPlayCount++;

        MOBSOUND.PlayOneShot(MobSound);

        StartCoroutine(ResetIsPlaying(MobSound.length));
    }

    IEnumerator ResetIsPlaying(float delay){
        yield return new WaitForSeconds(delay);
        currentPlayCount--;
    }
}
