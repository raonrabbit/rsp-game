using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSetter : MonoBehaviour
{
    public static StartSetter instance;
    void Awake() => instance = this;
    public GameObject[] objects;
    public Slider slider;
    public GameObject range01;
    public GameObject range02;
    public GameObject range03;
    public GameObject AmountSetUI;

    public List<GameObject> spawnedObject01 = new List<GameObject>();
    public List<GameObject> spawnedObject02 = new List<GameObject>();
    public List<GameObject> spawnedObject03 = new List<GameObject>();
    public bool isStart = false;

    void Start()
    {
        Time.timeScale = 0;
        objects = shuffleArray(objects);
        spawn(range01, objects[0], spawnedObject01);
        spawn(range02, objects[1], spawnedObject02);
        spawn(range03, objects[2], spawnedObject03);
        Destroy(gameObject, 3f);
    }

    void Update(){
        updateAmount(spawnedObject01);
        updateAmount(spawnedObject02);
        updateAmount(spawnedObject03);
    }

    void spawn(GameObject spawnBox, GameObject spawnObject, List<GameObject> spawnedObject){
        Vector2 originPosition = spawnBox.transform.position;
        BoxCollider2D rangeCollider = spawnBox.GetComponent<BoxCollider2D>();

        float Range_X = rangeCollider.bounds.size.x;
        float Range_Y = rangeCollider.bounds.size.y;

        for(int i = 0; i < 100; i++){
            float range_X = Random.Range((Range_X / 2) * -1, Range_X / 2);
            float range_Y = Random.Range((Range_Y / 2) * -1, Range_Y / 2);

            Vector2 RandomPosition = new Vector2(range_X, range_Y);
            Vector2 spawnPosition = originPosition + RandomPosition;
            //Instantiate(spawnObject, spawnPosition, transform.rotation);
            GameObject obj = GameManager.instance.pool.Get(spawnObject);
            obj.transform.position = spawnPosition;
            spawnedObject.Add(obj);
        }

    }

    public T[] shuffleArray<T>(T[] array){
        int random1, random2;
        T temp;

        for(int i = 0; i < array.Length; ++i){
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }
        return array;
    }

    void updateAmount(List<GameObject> spawnedObjects){
        float amount = slider.value;
        int i = 0;
        foreach(GameObject spawnedObject in spawnedObjects){
            if(i < amount) spawnedObject.SetActive(true);
            else spawnedObject.SetActive(false);
            i++;
        }
    }

    public void OnClickStart(){
        AmountSetUI.SetActive(false);
        freeObjects(spawnedObject01);
        freeObjects(spawnedObject02);
        freeObjects(spawnedObject03);
        Time.timeScale = 1;
        isStart = true;
        gameObject.SetActive(false);
    }

    void freeObjects(List<GameObject> spawnedObjects){
        foreach(GameObject spawnedObject in spawnedObjects){
            if(spawnedObject.activeSelf == false) GameManager.instance.pool.ReturnQ(spawnedObject);
        }
    }
}
