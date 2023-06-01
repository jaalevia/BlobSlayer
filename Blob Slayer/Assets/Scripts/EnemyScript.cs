using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public Canvas Canvas;
    //public GameObject AppearingDamage;
    public int MaxHealth = 10;
    public int CurrentHealth;
    public HealthBarScript HealthBar;
    public EnemySpawner SpawnerScript;
    public InkManager InkScript;
    public int _takeDmg = 2;
    PopOutScript popOutScript;
    public TextMeshPro textMesh;
    

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

    void OnMouseDown()
    {
        TakeDamage(_takeDmg);
    }

    public void TakeDamage(int damage)
    {
        popOutScript = GameObject.Find("GamingSystem").GetComponent<PopOutScript>();
        popOutScript.CreatePopUp();
        CurrentHealth -= damage;
        HealthBar.SetHealth(CurrentHealth);
    }
}
