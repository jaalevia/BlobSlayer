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
    public TextMeshProUGUI HealthBarDamage;
    public float MaxHealth;
    public float CurrentHealth;
    public HealthBarScript HealthBar;
    public NewShopScript NewShop;
    public EnemySpawner SpawnerScript;
    public InkManager InkScript;
    public PopOut Pop;
    public TextMeshProUGUI TextMeshPop;
    //public Image Imgae;
    //private Color _imageColor;
    public int _takeDmg;
    //private Animation anim;

    void Start()
    {
        //Imgae = gameObject.GetComponent<Image>();
        //_imageColor = Imgae.color;
        HealthBar = GameObject.FindGameObjectWithTag("SliderHealth").GetComponent<HealthBarScript>();
        HealthBarDamage = GameObject.Find("Damage").GetComponent<TextMeshProUGUI>();
        NewShop = GameObject.Find("NewShop").GetComponent<NewShopScript>();
        MaxHealth = HealthBar.MaxHealthCurrent;
        _takeDmg = NewShop._dropDamageTracker;
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
        HealthBarDamage.text = CurrentHealth.ToString();
        //Debug.Log(Imgae.color);
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

            HealthBar.MaxHealthCurrent = HealthBar.MaxHealthCurrent + 1;

            /*float disappearSpeed = 3f;
            _imageColor.a -= disappearSpeed * Time.deltaTime;
            Imgae.color = _imageColor;
            Debug.Log(Imgae.color);*/
            //anim = gameObject.GetComponent<Animation>();
            //anim.Play();


            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TakeDamage(_takeDmg);
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("Damage Sound");
        CurrentHealth -= damage;
        Pop = GameObject.Find("PopUpSpawner").GetComponent<PopOut>();
        Pop.CreatePopUp();
        HealthBar.SetHealth(CurrentHealth);
        HealthBarDamage.text = CurrentHealth.ToString();
    }
}
