using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopOutScript : MonoBehaviour
{
    public GameObject[] spawnToObject = new GameObject[3];
    public static PopOutScript current;
    public GameObject prefab;
    public EnemyScript enemy;

    private void Awake()
    {
        current = this;
    }

    public void CreatePopUp()
    {
        int a = Random.Range(0, spawnToObject.Length);
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        prefab.GetComponent<TextMeshPro>().SetText(enemy._takeDmg.ToString());
        GameObject popup = Instantiate(prefab, spawnToObject[a].transform.position, Quaternion.identity);
        popup.transform.SetParent(spawnToObject[a].transform);
        

        

        Destroy(popup, 0.3f);
    }
}
