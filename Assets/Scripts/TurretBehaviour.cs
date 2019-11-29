using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] BulletEffect;
    [SerializeField] private Transform ObjectToTurn;
    public PathFollowing[] pathFollow = new PathFollowing[300];
    public float radius = 0.5f;
    public GameObject UpgradeMenu;
    public Collider[] hitCollider = new Collider[0];
    public List<GameObject> InRangeEnemys = new List<GameObject>();
    public int currentEnemy = 0;
    public int currentSize = 0;

    void Start()
    {
        BulletEffect = GetComponentsInChildren<ParticleSystem>();
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
    private void AttackRadius(Vector3 center, float radius)
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
                        pathFollow[x] = hitCollider[x].gameObject.GetComponent<PathFollowing>();
                        int highest = Mathf.Max(pathFollow[x].currentWayPoint);
                        float highestDistance = Mathf.Min(pathFollow[x].distance);
                        ObjectToTurn.LookAt(pathFollow[Mathf.FloorToInt(highestDistance)].transform.position);
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
    private void Fire()
    {
        for (int i = 0; i < BulletEffect.Length; i++)
        {
            if (!BulletEffect[i].isPlaying)
            {
                BulletEffect[i].Play();
            }
        }
    }
    private void StopFiring()
    {
        for (int i = 0; i < BulletEffect.Length; i++)
        {
            BulletEffect[i].Stop();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
