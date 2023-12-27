using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public Text Rock_count;
    public Text Scissers_count;
    public Text Paper_count;

    public windowFunction resultWindow;
    public windowFunction amoutSetWindow;
    public windowFunction soundSetWindow;
    public windowFunction retryFocus;
    public GameObject[] WinnerObjects;

    private bool gameEnded;
    void Awake(){
        gameEnded = false;
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }

        //Amout 설정 초기화
        if(!PlayerPrefs.HasKey("Amout"))
        {
            PlayerPrefs.SetInt("Amout", 50);
        }

        //Speed 설정 초기화
        if(!PlayerPrefs.HasKey("Speed"))
        {
            PlayerPrefs.SetFloat("Speed", 3 * 0.25f);
        }
    }

    void Start(){
        amoutSetWindow.Show();
        resultWindow.Hide();
        soundSetWindow.Hide();
    }

    void Update(){
        if(!gameEnded){
            gameEndDetector();
        }
        Rock_count.text = pool.ObjCount[0].ToString();
        Scissers_count.text = pool.ObjCount[1].ToString();
        Paper_count.text = pool.ObjCount[2].ToString();
    }

    void gameEndDetector(){
        if(pool.ObjCount[0] == 0){
            gameEnded = true;
            showResult("Scissors");
            return;
        }
        if(pool.ObjCount[1] == 0){
            gameEnded = true;
            showResult("Paper");
            return;
        }
        if(pool.ObjCount[2] == 0){
            gameEnded = true;
            showResult("Rock");
            return;
        }
    }

    void showResult(string winnername){
        resultWindow.Show();
        retryFocus.Show();
        if(winnername == "Rock") WinnerObjects[0].SetActive(true);
        else if(winnername == "Scissors") WinnerObjects[1].SetActive(true);
        else if(winnername == "Paper") WinnerObjects[2].SetActive(true);
    }
}
