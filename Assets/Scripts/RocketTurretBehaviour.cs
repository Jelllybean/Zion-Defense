using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTurretBehaviour : TurretBehaviour
{
    [SerializeField] private List<GameObject> m_Rockets = new List<GameObject>(5);
    [SerializeField] private List<ParticleSystem> m_RocketParticles = new List<ParticleSystem>(15);
    private List<DisableRockets> m_DisableRocket = new List<DisableRockets>();
    [HideInInspector] public List<Vector3> m_RocketStartPositions = new List<Vector3>();

    public List<bool> m_CanRocketFire = new List<bool>(5);
    private bool m_CanFire = false;

    void Start()
    {
        for (int i = 0; i < m_RocketParticles.Count; i++)
        {
            m_RocketParticles[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < m_Rockets.Count; i++)
        {
            m_RocketStartPositions.Add(m_Rockets[i].transform.position);
            m_DisableRocket.Add(m_Rockets[i].GetComponent<DisableRockets>());
        }

        StartCoroutine(FireRockets());
    }

    private void Update()
    {
        AttackRadius(transform.position, radius);

        for (int i = 0; i < m_CanRocketFire.Count; i++)
        {
            if (m_CanRocketFire[i])
            {
                m_Rockets[i].transform.Translate(m_Rockets[i].transform.forward * 0.03f, Space.World);
                m_Rockets[i].transform.GetChild(0).gameObject.SetActive(true);;
                m_Rockets[i].transform.GetChild(1).gameObject.SetActive(true);;
                m_Rockets[i].transform.GetChild(2).gameObject.SetActive(true); ;
            }
            else
            {
                m_Rockets[i].transform.GetChild(0).gameObject.SetActive(false);
                m_Rockets[i].transform.GetChild(1).gameObject.SetActive(false);
                m_Rockets[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public override void Fire()
    {
        m_CanFire = true;
    }

    public override void StopFiring()
    {
        m_CanFire = false;
    }

    private IEnumerator FireRockets()
    {
        while (true)
        {
            if (m_CanFire)
            {
                for (int i = 0; i < m_CanRocketFire.Count; i++)
                {
                    if (!m_CanRocketFire[i])
                    {
                        m_CanRocketFire[i] = true;
                        m_DisableRocket[i].DisableRocket();
                        yield return new WaitForSeconds(0.4f);
                        break;
                    }
                }
            }
            else
                yield return null;
        }
    }
}
