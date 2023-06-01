using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopOut : MonoBehaviour
{
    public List<GameObject> spawnToObject = new List<GameObject>();
    public static PopOut current;
    public GameObject prefab;
    public EnemyScript enemy;
    public TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        current = this;
    }

    public void CreatePopUp()
    {
        int a = Random.Range(0, spawnToObject.Count);
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        GameObject popup = Instantiate(prefab, spawnToObject[a].transform.position, Quaternion.identity);
        popup.transform.SetParent(spawnToObject[a].transform);
        textMeshProUGUI = GameObject.FindGameObjectWithTag("Pop Up").GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.SetText(enemy._takeDmg.ToString());

        Destroy(popup, 0.3f);
    }
}
