using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void TurnToTitleScene(){
        SceneManager.LoadScene("Title");
    }
    public void TurnToPlayScene(){
        SceneManager.LoadScene("Play");
    }
}
