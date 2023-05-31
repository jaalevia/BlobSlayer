using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickScript : MonoBehaviour
{
    public EnemyScript EnemyAutoManagerScript;
    public int[] Seconds = new int[4];
    int i = 0;
    private void Update()
    {
        EnemyAutoManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
    }
    public void AutoClickButtonDown()
    {
        if (i <= 3)
        {   
            i++;
        }
        if (i == 1)
        {
            StartCoroutine(WaitingTime());
        }
    }

    private IEnumerator WaitingTime()
    {
        while (true)
        {
            Debug.Log(Seconds[i]);
            yield return new WaitForSeconds(Seconds[i]);
            EnemyAutoManagerScript.TakeDamage(2);
        }
    }
}
