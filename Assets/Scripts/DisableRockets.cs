using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRockets : BulletScript
{
    private RocketTurretBehaviour m_RocketBehaviour;
    public int m_RocketNumber;

    private void Awake()
    {
        m_RocketBehaviour = transform.root.GetComponent<RocketTurretBehaviour>();
    }

    public void DisableRocket()
    {
        Invoke("hideBullet", 2.0f);
    }

    public override void hideBullet()
    {
        base.hideBullet();
        m_RocketBehaviour.m_CanRocketFire[m_RocketNumber] = false;
        transform.position = m_RocketBehaviour.m_RocketStartPositions[m_RocketNumber];
    }
}
