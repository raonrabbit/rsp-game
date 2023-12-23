using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playToggleSound : MonoBehaviour
{
    public void onClickButton(){
        SoundManager.instance.PlaySFXSound("ToggleClick");
    }
}
