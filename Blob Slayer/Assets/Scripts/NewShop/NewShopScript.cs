using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewShopScript : MonoBehaviour
{
    public InkManager InkManagerScript;
    public EnemyScript EnemyManagerScript;

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
    public float BlutterPrice;

    [Header("Начальное время автокликера")]
    public float AutoClickerTime;

    private int _penInt = 1;
    private int _inkInt = 1;
    private int _blutterInt = 1;
    private int _takeDamageTracker = 0;
    private int _coroutineTracker = 0;

    
    

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
        PenPrice *= 2;
        _penInt++;
        PenText.text = "" + _penInt.ToString();
        PenPriceText.text = "" + PenPrice.ToString();
        EnemyManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        _takeDamageTracker++;
        
        EnemyManagerScript._takeDmg += _takeDamageTracker;
    }

    public void InkButtonDown()
    {
        InkPrice *= 2;
        _inkInt++;
        InkText.text = "" + _inkInt.ToString();
        InkPriceText.text = "" + InkPrice.ToString();
        InkManagerScript.HowMuchToAdd += 1;
    }

    public void BlutterButtonDown()
    {
        BlutterPrice = Mathf.Round(BlutterPrice *= 1.5f);
        EnemyManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        if (_coroutineTracker == 0)
        {
            StartCoroutine(WaitingTime());
        }
        _coroutineTracker = 1;
        _blutterInt++;
        BlutterText.text = "" + _blutterInt.ToString();
        BlutterPriceText.text = "" + BlutterPrice.ToString();
        AutoClickerTime -= 0.5f;
        Debug.Log(AutoClickerTime);
        
    }

    private IEnumerator WaitingTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(AutoClickerTime);
            EnemyManagerScript.TakeDamage(EnemyManagerScript._takeDmg);
        }
    }
}
