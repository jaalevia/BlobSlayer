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

    private void Awake()
    {
        current = this;
    }

    public void CreatePopUp()
    {
        int a = Random.Range(0, spawnToObject.Count);
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        prefab.GetComponent<TextMeshProUGUI>().SetText(enemy._takeDmg.ToString());
        GameObject popup = Instantiate(prefab, spawnToObject[a].transform.position, Quaternion.identity);
        popup.transform.SetParent(spawnToObject[a].transform);

        Destroy(popup, 0.2f);
    }
}
