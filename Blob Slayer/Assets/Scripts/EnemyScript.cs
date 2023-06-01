using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour, IPointerClickHandler
{
    //public Canvas Canvas;
    //public GameObject AppearingDamage;
    public TextMeshProUGUI HealthBarDamage;
    public float MaxHealth = 10;
    public float CurrentHealth;
    public HealthBarScript HealthBar;
    public NewShopScript NewShop;
    public EnemySpawner SpawnerScript;
    public InkManager InkScript;
    public int _takeDmg;

    void Start()
    {
        HealthBar = GameObject.FindGameObjectWithTag("SliderHealth").GetComponent<HealthBarScript>();
        HealthBarDamage = GameObject.Find("Damage").GetComponent<TextMeshProUGUI>();
        NewShop = GameObject.Find("NewShop").GetComponent<NewShopScript>();
        _takeDmg = NewShop._dropDamageTracker;
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
        HealthBarDamage.text = CurrentHealth.ToString();
    }

    void Update()

    {
        if (CurrentHealth < MaxHealth / 2)
        {
            HealthBarDamage.color = Color.black;
        }
        else
        {
            HealthBarDamage.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(_takeDmg);
        }
        if (CurrentHealth <= 0)
        {
            SpawnerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>(); 
            SpawnerScript.Spawn();

            InkScript = GameObject.FindGameObjectWithTag("Inky").GetComponent<InkManager>();
            InkScript.AddInk();

            Destroy(gameObject);
            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TakeDamage(_takeDmg);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(NewShop._dropDamageTracker);
        FindObjectOfType<AudioManager>().Play("Damage Sound");
        CurrentHealth -= damage;
        HealthBar.SetHealth(CurrentHealth);
        HealthBarDamage.text = CurrentHealth.ToString();
    }
}
