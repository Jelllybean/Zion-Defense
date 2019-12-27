using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurretBehaviour : TurretBehaviour
{
    public GameObject m_LaserBlast;
    public Transform m_BulletEmitter;
    //private GameObject[] m_LaserBlasts = new GameObject[20];
    private List<GameObject> m_LaserBlasts = new List<GameObject>(15);

    private void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject laser = Instantiate(m_LaserBlast);
            m_LaserBlasts.Add(laser);
            laser.transform.position = m_BulletEmitter.position;
            laser.transform.parent = gameObject.transform;
            laser.SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < m_LaserBlasts.Count; i++)
        {
            if (m_LaserBlasts[i].activeInHierarchy)
            {
                m_LaserBlasts[i].transform.Translate(m_LaserBlasts[i].transform.forward * 0.03f);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(FireLasers());
        }
        else
        {
            StopFiring();
        }
    }

    public override void Fire()
    {
        StartCoroutine(FireLasers());
    }

    public override void StopFiring()
    {
        StopCoroutine(FireLasers());
    }

    private IEnumerator FireLasers()
    {
        for (int i = 0; i < m_LaserBlasts.Count; i++)
        {
            if (!m_LaserBlasts[i].activeInHierarchy)
            {
                m_LaserBlasts[i].SetActive(true);
                m_LaserBlasts[i].transform.position = m_BulletEmitter.position;
            }
            if (i >= m_LaserBlasts.Count)
                i = 0;
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
}
