using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewShopScript : MonoBehaviour
{
    [Header("Текстовые поля для уровня")]
    public TextMeshProUGUI PenText;
    public TextMeshProUGUI InkText;
    public TextMeshProUGUI BlutterText;

    [Header("Текстовые поля для цены")]
    public TextMeshProUGUI PenPriceText;
    public TextMeshProUGUI InkPriceText;
    public TextMeshProUGUI BlutterPriceText;

    [Header("Цена")]
    public int PenPrice;
    public int InkPrice;
    public int BlutterPrice;

    private int _penInt = 1;
    private int _inkInt = 1;
    private int _blutterInt = 1;
    

    private void Start()
    {
        PenPriceText.text = "" + PenPrice.ToString();
        InkPriceText.text = "" + InkPrice.ToString();
        BlutterPriceText.text = "" + BlutterPrice.ToString();

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
