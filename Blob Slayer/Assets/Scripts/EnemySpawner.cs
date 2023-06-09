using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyList = new List<GameObject>();
    public GameObject SpawnToObject;
    private uint enemyCounter;
    [SerializeField] private GameObject endCutScene;
    [SerializeField] private uint enemyToCutScene;

    void Start()
    {
        endCutScene.SetActive(false);
        Spawn();
    }

    public void Spawn()
    {
        GameObject newObject = Instantiate(EnemyList[Random.Range(0, EnemyList.Count)], SpawnToObject.transform.position, Quaternion.identity);
        newObject.transform.SetParent(SpawnToObject.transform);
        enemyCounter++;
        if (enemyCounter > enemyToCutScene)
        {
            endCutScene.SetActive(true);
        }
    }
}
