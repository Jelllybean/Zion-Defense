using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDamage : MonoBehaviour
{
    private RaycastHit hit;
    private int layerMask = 1 << 11;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
    }
    public void ShootRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000, layerMask))
        {
            DamageScript damageScript = hit.collider.gameObject.GetComponent<DamageScript>();
            if (damageScript != null)
            {
                //damageScript.HealthPoints -= 25;
            }
        }
    }
}
