using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public float HealthPoints = 100;
    private float lastHealth = 91;
    private TotalMoney MoneyCounter;
    private RoundSystem roundSystem;

    private void Start()
    {
        MoneyCounter = FindObjectOfType<TotalMoney>();
    }

    private void OnEnable()
    {
        HealthPoints = lastHealth;
        HealthPoints = 1.1F * HealthPoints;
        lastHealth = HealthPoints;
    }
    void Update()
    {
        if (HealthPoints <= 0)
        {
            gameObject.SetActive(false);
            MoneyCounter.totalMoneyCounter += 15;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        HealthPoints -= 5;
    }
}
