using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkBoostScript : MonoBehaviour
{
    public InkManager InkManagerScript;
    public int[] InkBooster = new int[3];
    int i = 0;

    public void InkButtonDown()
    {
        if ( i <= 3 )
        {
            InkManagerScript.HowMuchToAdd = InkBooster[i];
            i++;
        }
    }
}
