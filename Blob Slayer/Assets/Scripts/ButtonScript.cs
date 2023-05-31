using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{
    public Image[] images = new Image[3];
    int i = 0;
    public void OnButtonClick()
    {
        if (i <= 3)
        {
            images[i].color = Color.red;
            i++;
        }
        else
        {
            Destroy(gameObject); 
        }
         
    }
}
