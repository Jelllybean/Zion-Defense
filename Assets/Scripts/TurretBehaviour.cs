using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] BulletEffect;
    [SerializeField] private Transform ObjectToTurn;
    [SerializeField] private float radius;
    void Start()
    {
        BulletEffect = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        AttackRadius(transform.position, radius);
    }
    private void AttackRadius(Vector3 center, float radius)
    {
        Collider[] hitCollider = Physics.OverlapSphere(center, radius);
        int i = 0;
        if(hitCollider[i].tag == "Enemy")
        {
            ObjectToTurn.LookAt(hitCollider[i].transform.position);
            Fire();
        }
        else
        {
            StopFiring();
        }
    }
    private void Fire()
    {
        for (int i = 0; i < BulletEffect.Length; i++)
        {
            if(!BulletEffect[i].isPlaying)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
