using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgradeSystem : MonoBehaviour
{
    private TurretBehaviour turretBehaviour;
    public Transform sphere;
    private TotalMoney MoneyManager;
    [SerializeField] private GameObject DoubleBarrelTurret;
    private bool rangeHasBeenUpgraded = false;

    void Awake()
    {
        MoneyManager = FindObjectOfType<TotalMoney>();
        turretBehaviour = GetComponent<TurretBehaviour>();
    }

    public void UpgradeRange()
    {
        if (MoneyManager.totalMoneyCounter >= 250 && !rangeHasBeenUpgraded)
        {
            rangeHasBeenUpgraded = true;
            turretBehaviour.radius = 0.75f;
            sphere.localScale = sphere.localScale * 1.5f;
            MoneyManager.totalMoneyCounter -= 250;
        }
    }
    public void UpgradeBarrels()
    {
        if (MoneyManager.totalMoneyCounter >= 400)
        {
            GameObject turret = Instantiate(DoubleBarrelTurret, turretBehaviour.gameObject.transform.position, turretBehaviour.gameObject.transform.rotation);
            turret.GetComponent<TurretBehaviour>().radius = turretBehaviour.radius;
            if(turretBehaviour.radius > 0.5)
            {
                UpgradeRadius radiusSphere = turret.GetComponentInChildren<UpgradeRadius>();
                sphere.localScale = sphere.localScale * 1.5f;
            }
            MoneyManager.totalMoneyCounter -= 400;
            Destroy(turretBehaviour.gameObject);
        }
    }
}
