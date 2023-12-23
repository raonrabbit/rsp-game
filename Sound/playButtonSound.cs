using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonSound : MonoBehaviour
{
    public void onClickButton(){
        SoundManager.instance.PlaySFXSound("ButtonClick");
    }
}
