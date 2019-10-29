using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] BulletEffect;
    [SerializeField] private Transform ObjectToTurn;
    public float radius = 0.5f;
    public GameObject UpgradeMenu;
    public Collider[] hitCollider;
    void Start()
    {
        BulletEffect = GetComponentsInChildren<ParticleSystem>();
        UpgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AttackRadius(transform.position, radius);
    }
    private void AttackRadius(Vector3 center, float radius)
    {
        hitCollider = Physics.OverlapSphere(center, radius, 1 << 10);
        if (hitCollider.Length != 0)
        {
            for (int i = 0; i < hitCollider.Length; i++)
            {
                if (hitCollider[i].tag == "Enemy")
                {
                    ObjectToTurn.LookAt(hitCollider[i].transform.position);
                    Fire();
                    break;
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
