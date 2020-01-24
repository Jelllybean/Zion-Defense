using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurretBehaviour : TurretBehaviour
{
    public GameObject m_LaserBlast;
    public Transform m_BulletEmitter;
    private List<GameObject> m_LaserBlasts = new List<GameObject>(15);
    private bool m_CanFire = false;

    public override void Start()
    {
        base.Start();

        for (int i = 0; i < 50; i++)
        {
            GameObject laser = Instantiate(m_LaserBlast);
            m_LaserBlasts.Add(laser);
            laser.transform.position = m_BulletEmitter.position;
            laser.transform.rotation = m_BulletEmitter.rotation;
            laser.SetActive(false);
        }
        StartCoroutine(FireLasers());
    }

    void Update()
    {
        AttackRadius(transform.position, radius);
        //m_BulletEmitter.localEulerAngles = ObjectToTurn.localEulerAngles;
        //m_BulletEmitter.rotation = ObjectToTurn.rotation;
        for (int i = 0; i < m_LaserBlasts.Count; i++)
        {
            if (m_LaserBlasts[i].activeInHierarchy)
            {
                m_LaserBlasts[i].transform.Translate(m_LaserBlasts[i].transform.forward * 0.03f, Space.World);
            }
        }
        print(m_CanFire);
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Fire();
        //}
        //else
        //{
        //    StopFiring();
        //}
    }

    public override void Fire()
    {
        //StartCoroutine(FireLasers());
        m_CanFire = true;
    }

    public override void StopFiring()
    {
        //StopCoroutine(FireLasers());
        m_CanFire = false;
    }

    private IEnumerator FireLasers()
    {
        //for (int i = 0; i < m_LaserBlasts.Count; i++)
        //{
        //    if (!m_LaserBlasts[i].activeInHierarchy)
        //    {
        //        m_LaserBlasts[i].SetActive(true);
        //        //m_LaserBlasts[i].transform.position = m_BulletEmitter.position;
        //        //break;
        //    }
        //}
        while (true)
        {
            if (m_CanFire)
            {
                for (int i = 0; i < m_LaserBlasts.Count; i++)
                {
                    if (!m_LaserBlasts[i].activeInHierarchy)
                    {
                        m_LaserBlasts[i].SetActive(true);
                        yield return new WaitForSeconds(0.2f);
                        break;
                    }
                }
            }
            else
                yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
