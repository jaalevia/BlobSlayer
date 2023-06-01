using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour, IPointerClickHandler
{
    //public Canvas Canvas;
    //public GameObject AppearingDamage;
    public int MaxHealth = 10;
    public int CurrentHealth;
    public HealthBarScript HealthBar;
    public EnemySpawner SpawnerScript;
    public InkManager InkScript;
    public int _takeDmg = 2;

    void Start()
    {
        HealthBar = GameObject.FindGameObjectWithTag("SliderHealth").GetComponent<HealthBarScript>();
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(_takeDmg);
            //ShowDamageTaken();
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
        //ShowDamageTaken();
    }

    /*void ShowDamageTaken()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        Instantiate(AppearingDamage, AppearingDamage.transform.position, Quaternion.identity);
        gameObject.transform.SetParent(Canvas.transform);
        AppearingDamage.text = "Hello World!";
        
    }*/
    public void TakeDamage(int damage)
    { 
        CurrentHealth -= damage;
        HealthBar.SetHealth(CurrentHealth);
    }
}
