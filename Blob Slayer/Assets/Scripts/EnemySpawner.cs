using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject SpawnToObject;

    void Start()
    {
       
        Spawn();
    }

    void Spawn()
    {
        GameObject newObject = Instantiate(EnemyList[Random.Range(0, EnemyList.Count)], SpawnToObject.transform.position, Quaternion.identity);
        newObject.transform.SetParent(SpawnToObject.transform);
    }
}
