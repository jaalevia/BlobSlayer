using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewShopScript : MonoBehaviour
{
    public TextMeshProUGUI PenText;
    private int _penInt = 1;
    public TextMeshProUGUI InkText;
    private int _inkInt = 1;
    public TextMeshProUGUI BlutterText;
    private int _blutterInt = 1;

    private void Start()
    {
        PenText.text = "" + _penInt.ToString();
        InkText.text = "" + _inkInt.ToString();
        BlutterText.text = "" + _blutterInt.ToString();
    }
    public void PenButtonDown()
    {
        _penInt++;
        PenText.text = "" + _penInt.ToString();
    }

    public void InkButtonDown()
    {
        _inkInt++;
        InkText.text = "" + _inkInt.ToString();
    }

    public void BlutterButtonDown()
    {
        _blutterInt++;
        BlutterText.text = "" + _blutterInt.ToString();
    }
}
