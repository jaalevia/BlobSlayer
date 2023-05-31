using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostScript : MonoBehaviour
{
    public EnemyScript EnemyManagerScript;
    public int[] DamageBooster = new int[4];
    int i = 0;
    public void DamageButtonDown()
    {
        if (i <= 4)
        {
            EnemyManagerScript._takeDmg = DamageBooster[i]; 
            i++;
        }
    }

    private void Update()
    {
        
        EnemyManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        EnemyManagerScript._takeDmg = DamageBooster[i];

    }
}
