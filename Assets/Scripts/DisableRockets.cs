using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRockets : MonoBehaviour
{
    private RocketTurretBehaviour m_RocketBehaviour;
    private Transform m_Parent;
    public int m_RocketNumber;

    private void Awake()
    {
        m_RocketBehaviour = transform.root.GetComponent<RocketTurretBehaviour>();
        m_Parent = transform.parent;
    }

    public void DisableRocket()
    {
        Invoke("hideBullet", 2.0f);
    }

    public void HideRocket()
    {
        m_RocketBehaviour.m_CanRocketFire[m_RocketNumber] = false;
        transform.position = m_RocketBehaviour.m_RocketStartPositions[m_RocketNumber];
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * 4);
    }
}
