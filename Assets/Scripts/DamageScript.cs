using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int HealthPoints = 100;
    private Steering DeadVelocity;
    private Rigidbody Rb;
    [SerializeField] private GameObject DeadBoidPrefab;

    private void Start()
    {
        DeadVelocity = GetComponent<Steering>();
    }
    void Update()
    {
        if(HealthPoints <= 0)
        {
            Instantiate(DeadBoidPrefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
            gameObject.SetActive(false);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        HealthPoints -= 10;
    }
}
