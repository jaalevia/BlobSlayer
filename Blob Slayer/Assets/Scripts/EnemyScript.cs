using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int MaxHealth = 10;
    public int CurrentHealth;
    public HealthBarScript HealthBar;

    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
    }

    void OnMouseDown()
    {
        TakeDamage(2);
    }

    void TakeDamage(int damage)
    { 
        CurrentHealth -= damage;
        HealthBar.SetHealth(CurrentHealth);
    }
}
