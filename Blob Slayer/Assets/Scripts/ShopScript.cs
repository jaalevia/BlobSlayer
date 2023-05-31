using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopScript : MonoBehaviour
{
    public GameObject ShopPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && ShopPanel.activeInHierarchy == false)
        {
            ShopPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && ShopPanel.activeInHierarchy == true)
        {
            ShopPanel.SetActive(false);
        }
    }
}
