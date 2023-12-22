using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    Queue<GameObject>[] pools;
    public int[] ObjCount;

    void Awake(){
        pools = new Queue<GameObject>[prefabs.Length];
        ObjCount = new int[3]{0, 0, 0};
        for(int index = 0; index < pools.Length; index++){
            pools[index] = new Queue<GameObject>();
            for(int i = 0; i < 300; i++){
                GameObject obj = Instantiate(prefabs[index], transform);
                obj.SetActive(false);
                pools[index].Enqueue(obj);
            }
        }
    }

    public GameObject Get(GameObject obj)
    {
        int index = 0;
        if(obj == prefabs[0]) index = 0;
        else if(obj == prefabs[1]) index = 1;
        else if(obj == prefabs[2]) index = 2;
        GameObject select = null;
        select = pools[index].Dequeue();
        ObjCount[index] += 1;
        select.SetActive(true);
        return select;
    }

    public void ReturnQ(GameObject obj){
        int index = 0;
        if(obj.tag == prefabs[0].tag) index = 0;
        else if(obj.tag == prefabs[1].tag) index = 1;
        else if(obj.tag == prefabs[2].tag) index = 2;
        pools[index].Enqueue(obj);
        ObjCount[index] -= 1;
        obj.SetActive(false);
    }
}
