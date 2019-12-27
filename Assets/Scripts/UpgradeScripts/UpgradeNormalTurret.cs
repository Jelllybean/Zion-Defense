using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeNormalTurret : UpgradeScript
{
    private TurretBehaviour m_TurretBehaviour;
    private TotalMoney m_MoneyManager;
    private GameObject m_DoubleFireRateTurret;

    void Awake()
    {
        if (!m_MoneyManager)
            m_MoneyManager = FindObjectOfType<TotalMoney>();
        if (!m_TurretBehaviour)
            m_TurretBehaviour = GetComponent<TurretBehaviour>();
    }


    public override void Upgrade1_0()
    {
        base.Upgrade1_0();
        m_TurretBehaviour.radius = 0.75f;
        sphere.localScale = sphere.localScale * 1.5f;
        m_MoneyManager.totalMoneyCounter -= 250;
    }

    public override void Upgrade2_0()
    {
        base.Upgrade2_0();
    }

    public override void Upgrade3_0()
    {
        base.Upgrade3_0();
    }

    public override void Upgrade4_0()
    {
        base.Upgrade4_0();
    }


    public override void Upgrade0_1()
    {
        base.Upgrade0_1();
        GameObject turret = Instantiate(m_DoubleFireRateTurret, m_TurretBehaviour.gameObject.transform.position, m_TurretBehaviour.gameObject.transform.rotation);
        turret.GetComponent<TurretBehaviour>().radius = m_TurretBehaviour.radius;
        if (m_TurretBehaviour.radius > 0.5)
        {
            //UpgradeRadius radiusSphere = turret.GetComponent<UpgradeRadius>();
            sphere.localScale = sphere.localScale * 1.5f;
        }
        m_MoneyManager.totalMoneyCounter -= 400;
        Destroy(m_TurretBehaviour.gameObject);
    }

    public override void Upgrade0_2()
    {
        base.Upgrade0_2();
    }
    public override void Upgrade0_3()
    {
        base.Upgrade0_3();
    }
    public override void Upgrade0_4()
    {
        base.Upgrade0_4();
    }
}
