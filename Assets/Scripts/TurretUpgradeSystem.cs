using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgradeSystem : MonoBehaviour
{
    private TurretBehaviour turretBehaviour;
    [SerializeField] private GameObject DoubleBarrelTurret;

    void Start()
    {
        turretBehaviour = GetComponent<TurretBehaviour>();
    }

    public void UpgradeRange()
    {
        turretBehaviour.radius = 0.75f;
    }
    public void UpgradeBarrels()
    {
        GameObject turret =  Instantiate(DoubleBarrelTurret, turretBehaviour.gameObject.transform.position, turretBehaviour.gameObject.transform.rotation);
        turret.GetComponent<TurretBehaviour>().radius = turretBehaviour.radius;
        UpgradeRadius radiusSphere = turret.GetComponentInChildren<UpgradeRadius>();
        radiusSphere.sphere.localScale = radiusSphere.sphere.localScale * 1.5f;
        Destroy(turretBehaviour.gameObject);
    }
}
