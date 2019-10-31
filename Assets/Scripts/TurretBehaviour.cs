using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] BulletEffect;
    [SerializeField] private Transform ObjectToTurn;
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
                    ObjectToTurn.LookAt(hitCollider[i].transform.position);
                    Fire();
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
