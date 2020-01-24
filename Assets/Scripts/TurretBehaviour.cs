using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform[] ObjectToTurn;
    public PathFollowing[] pathFollow = new PathFollowing[300];
    public float radius = 0.5f;
    public GameObject UpgradeMenu;
    //public Collider[] hitCollider = new Collider[0];
    public List<GameObject> InRangeEnemys = new List<GameObject>();
    public int currentEnemy = 0;
    public int currentSize = 0;

    private float m_LowestDistance;

    public List<float> m_Distances = new List<float>();
    public List<PathFollowing> m_PathFollow = new List<PathFollowing>();

    private EnemyManager m_EnemyManager;

    public virtual void Start()
    {
        m_EnemyManager = FindObjectOfType<EnemyManager>();
        //m_Distances = new List<float>(m_EnemyManager.m_EnemyDistance);
        UpgradeMenu.SetActive(false);
    }

    void Update()
    {
        AttackRadius(transform.position, radius);

        //while (currentSize < hitCollider.Length)
        //{
        //    InRangeEnemys.Add(hitCollider[currentSize].gameObject);
        //    currentSize++;
        //}
        //if (hitCollider.Length > currentSize)
        //{
        //    InRangeEnemys.Add(hitCollider[currentSize].gameObject);
        //    currentSize += 1;
        //}
        //for (int i = 0; i < InRangeEnemys.Count; i++)
        //{
        //if (InRangeEnemys[0] != null)
        //{
        //    if (InRangeEnemys[0].activeSelf == false)
        //    {
        //        InRangeEnemys.Remove(InRangeEnemys[0]);
        //    }
        //    //float distance = Vector3.Distance(transform.position, InRangeEnemys[0].transform.position);
        //    //if (distance >= radius)
        //    //{
        //    //    InRangeEnemys.Remove(InRangeEnemys[0]);
        //    //}
        //}
        //}
    }
    public void AttackRadius(Vector3 center, float radius)
    {
        //for (int i = 0; i < m_EnemyManager.m_EnemyDistance.Count; i++)
        //{
        //    float distance = Vector3.Distance(center, m_EnemyManager.m_EnemyPathFollowing[i].transform.position);
        //    if (distance <= radius && !m_PathFollow.Contains(m_EnemyManager.m_EnemyPathFollowing[i]))
        //    {
        //        m_PathFollow.Add(m_EnemyManager.m_EnemyPathFollowing[i]);
        //        m_Distances[i] = m_EnemyManager.m_EnemyDistance[i];
        //    }
        //    else if (distance > radius && m_PathFollow.Contains(m_EnemyManager.m_EnemyPathFollowing[i]))
        //    {
        //        m_PathFollow.Remove(m_EnemyManager.m_EnemyPathFollowing[i]);
        //        m_Distances[i] = m_EnemyManager.m_EnemyDistance[i];
        //    }
        //}
        //
        //foreach (float enemy in m_Distances)
        //{
        //
        //}
        //
        //if (m_PathFollow.Count != 0)
        //{
        //    int _indexOf = m_Distances.IndexOf(m_Distances.Min());
        //    for (int y = 0; y < ObjectToTurn.Length; y++)
        //        ObjectToTurn[y].LookAt(m_PathFollow[_indexOf].transform.position);
        //    Fire();
        //}
        //else
        //    StopFiring();
        //for (int i = 0; i < m_EnemyManager.m_EnemyPathFollowing.Count; i++)
        //{
        //    if (m_EnemyManager.m_EnemyPathFollowing[i].isActiveAndEnabled)
        //    {
        //        float distance = Vector3.Distance(center, m_EnemyManager.m_EnemyPathFollowing[i].transform.position);
        //        if (distance < radius)
        //        {
        //            m_PathFollow.Add(m_EnemyManager.m_EnemyPathFollowing[i]);
        //        }
        //        else if (m_PathFollow.Contains(m_EnemyManager.m_EnemyPathFollowing[i]))
        //        {
        //            m_PathFollow.Remove(m_EnemyManager.m_EnemyPathFollowing[i]);
        //        }
        //    }
        //}
        Collider[] hitCollider = (Physics.OverlapSphere(transform.position, radius, 1 << 10));
        if (hitCollider.Length != 0)
        {
            for (int i = 0; i < hitCollider.Length; i++)
            {
                if (hitCollider[i].gameObject.activeSelf)
                {
                    //get the highest waypoint
                    //pathFollow[x] = \
                    //PathFollowing _currentWayPoint = hitCollider[i].gameObject.GetComponent<PathFollowing>();
                    PathFollowing _currentWayPoint = hitCollider[i].gameObject.GetComponent<PathFollowing>();
                    GameObject _currentObject = _currentWayPoint.gameObject;
                    if (_currentWayPoint.m_EntireDistance < m_LowestDistance)
                    {
                        m_LowestDistance = _currentWayPoint.m_EntireDistance;
                        _currentObject = _currentWayPoint.gameObject;
                    }
                    //if (_currentWayPoint.currentWayPoint <= Mathf.Max(m_WayPoints.ToArray()))
                    //{
                    //int _indexOf = m_Distances.IndexOf(m_Distances.Min());
                    // = m_Distances.IndexOf(Mathf.Min(m_Distances.ToArray()));
                    //int highest = Mathf.Max(pathFollow[x].currentWayPoint);
                    //float highestDistance = Mathf.Min(pathFollow[x].distance);
                    for (int y = 0; y < ObjectToTurn.Length; y++)
                        ObjectToTurn[y].LookAt(_currentObject.transform.position);
                    Fire();
                    //if (!m_Distances.Contains(_currentWayPoint.m_EntireDistance) && !m_PathFollow.Contains(_currentWayPoint))
                    //{
                    //    m_Distances.Add(_currentWayPoint.m_EntireDistance);
                    //    m_PathFollow.Add(_currentWayPoint);
                    //}
                    //
                    //for (int s = 0; s < m_PathFollow.Count; s++)
                    //{
                    //    float distance = Vector3.Distance(center, _currentWayPoint.transform.position);
                    //    if (!_currentWayPoint.gameObject.activeInHierarchy || distance > radius)
                    //    {
                    //        m_Distances.Remove(_currentWayPoint.m_EntireDistance);
                    //        m_PathFollow.Remove(_currentWayPoint);
                    //    }
                    //}
                    //}
                    //else if (_currentWayPoint.currentWayPoint > Mathf.Max(m_WayPoints.ToArray()))
                    //{
                    //    m_WayPoints.Clear();
                    //    m_WayPoints.Add(_currentWayPoint.currentWayPoint);
                    //    m_PathFollow.Add(_currentWayPoint);
                    //}
                    //int currentEnemy = x;
                    //for (int y = 0; y < hitCollider.Length; y++)
                    //{
                    //    float highest2 = Mathf.Min(pathFollow[y].distance);
                    //    int currentEnemy = y;
                    //    ObjectToTurn.LookAt(hitCollider[x].transform.position);
                    //    Fire();
                    //}


                }
            }
        }
        else
            StopFiring();
    }
    public virtual void Fire()
    {

    }
    public virtual void StopFiring()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
