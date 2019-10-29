using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float HealthPoints = 100;
    public float lastHealth;
    private TotalMoney MoneyCounter;
    private RoundSystem roundSystem;

    private void Start()
    {
        lastHealth = HealthPoints;
        MoneyCounter = FindObjectOfType<TotalMoney>();
    }

    private void OnEnable()
    {
        HealthPoints = lastHealth;
        //HealthPoints = 1.1F * HealthPoints;
        //lastHealth = HealthPoints;
    }
    void Update()
    {
        if (HealthPoints <= 0)
        {
            gameObject.SetActive(false);
            MoneyCounter.totalMoneyCounter += 10;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            HealthPoints -= 25;
            other.gameObject.SetActive(false);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        HealthPoints -= 5;
    }
}
