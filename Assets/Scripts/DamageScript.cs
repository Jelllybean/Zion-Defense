using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int HealthPoints = 100;
    private TotalMoney MoneyCounter;
    //[SerializeField] private GameObject DeadBoidPrefab;

    private void Start()
    {
        MoneyCounter = FindObjectOfType<TotalMoney>();
    }

    void Update()
    {
        if (HealthPoints <= 0)
        {
            //Instantiate(DeadBoidPrefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
            gameObject.SetActive(false);
            MoneyCounter.totalMoneyCounter += 150;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        HealthPoints -= 5;
    }
}
