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
    public Collider[] hitCollider = new Collider[0];
    public List<GameObject> InRangeEnemys = new List<GameObject>();
    public int currentEnemy = 0;
    public int currentSize = 0;

    private List<float> m_Distances = new List<float>();
    private List<PathFollowing> m_PathFollow = new List<PathFollowing>();

    void Start()
    {
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
        hitCollider = (Physics.OverlapSphere(transform.position, radius, 1 << 10));
        if (hitCollider.Length != 0)
        {
            for (int i = 0; i < hitCollider.Length; i++)
            {
                if (hitCollider[i].gameObject.activeSelf)
                {
                    for (int x = 0; x < hitCollider.Length; x++)
                    {
                        //get the highest waypoint
                        //pathFollow[x] = \
                        PathFollowing _currentWayPoint = hitCollider[x].gameObject.GetComponent<PathFollowing>();
                        //if (_currentWayPoint.currentWayPoint <= Mathf.Max(m_WayPoints.ToArray()))
                        //{
                            m_Distances.Add(_currentWayPoint.m_EntireDistance);
                            m_PathFollow.Add(_currentWayPoint);
                        //}
                        //else if (_currentWayPoint.currentWayPoint > Mathf.Max(m_WayPoints.ToArray()))
                        //{
                        //    m_WayPoints.Clear();
                        //    m_WayPoints.Add(_currentWayPoint.currentWayPoint);
                        //    m_PathFollow.Add(_currentWayPoint);
                        //}
                        int _indexOf = m_Distances.IndexOf(Mathf.Min(m_Distances.ToArray()));
                        // = m_Distances.IndexOf(Mathf.Min(m_Distances.ToArray()));
                        //int highest = Mathf.Max(pathFollow[x].currentWayPoint);
                        //float highestDistance = Mathf.Min(pathFollow[x].distance);
                        for (int y = 0; i < ObjectToTurn.Length; i++)
                            ObjectToTurn[y].LookAt(m_PathFollow[_indexOf].transform.position);
                        Fire();
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
