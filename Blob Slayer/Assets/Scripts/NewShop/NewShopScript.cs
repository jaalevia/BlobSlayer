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
    public float PenPrice;
    public float InkPrice;
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
        PenText.text = "" + _penInt.ToString();
        PenPriceText.text = "" + PenPrice.ToString();
        EnemyManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();

        if (InkManagerScript.inkCount >= PenPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade Sound");
            InkManagerScript.inkCount -= PenPrice;
            InkManagerScript.inkText.text = "Ink: " + InkManagerScript.inkCount.ToString();
            PenPrice *= 2;
            _penInt++;
            _takeDamageTracker++;
            EnemyManagerScript._takeDmg += _takeDamageTracker;
        }
        PenText.text = "" + _penInt.ToString();
        PenPriceText.text = "" + PenPrice.ToString();
    }

    public void InkButtonDown()
    {
        InkText.text = "" + _inkInt.ToString();
        InkPriceText.text = "" + InkPrice.ToString();

        if (InkManagerScript.inkCount >= InkPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade Sound");
            InkManagerScript.inkCount -= InkPrice;
            InkManagerScript.inkText.text = "Ink: " + InkManagerScript.inkCount.ToString();
            InkPrice *= 2;
            _inkInt++;
            InkManagerScript.HowMuchToAdd += 1;
        }
        InkText.text = "" + _inkInt.ToString();
        InkPriceText.text = "" + InkPrice.ToString();

    }

    public void BlutterButtonDown()
    {
        EnemyManagerScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        BlutterText.text = "" + _blutterInt.ToString();
        BlutterPriceText.text = "" + BlutterPrice.ToString();

        if (InkManagerScript.inkCount >= BlutterPrice)
        {
            FindObjectOfType<AudioManager>().Play("Upgrade Sound");

            if (_coroutineTracker == 0)
                {
                    StartCoroutine(WaitingTime());
                }

            _coroutineTracker = 1;
            BlutterPrice = Mathf.Round(BlutterPrice *= 1.5f);
            InkManagerScript.inkCount -= BlutterPrice;
            InkManagerScript.inkText.text = "Ink: " + InkManagerScript.inkCount.ToString();
            _blutterInt++;
            AutoClickerTime -= 0.5f;
            Debug.Log(AutoClickerTime);
            BlutterText.text = "" + _blutterInt.ToString();
            BlutterPriceText.text = "" + BlutterPrice.ToString();
        } 
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
