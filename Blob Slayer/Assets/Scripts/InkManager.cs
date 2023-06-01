using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    public TextMeshProUGUI inkText;

    public int HowMuchToAdd;
    [HideInInspector]
    public float inkCount;
    void Start()
    {
        inkText.text = "Ink: " + inkCount.ToString();
    }
    public void AddInk()
    {
        inkCount += HowMuchToAdd;
        inkText.text = "Ink: " + inkCount.ToString();
    }
}
