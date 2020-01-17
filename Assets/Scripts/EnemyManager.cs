using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    public List<PathFollowing> m_EnemyPathFollowing = new List<PathFollowing>();
    public List<float> m_EnemyDistance = new List<float>();

    private void Start()
    {
        //m_EnemyDistance = new List<float>(new float[400]);
    }

    private void Update()
    {
        for (int i = 0; i < m_EnemyPathFollowing.Count; i++)
        {
            m_EnemyDistance[i] = m_EnemyPathFollowing[i].m_EntireDistance; 
        }
    }
}
