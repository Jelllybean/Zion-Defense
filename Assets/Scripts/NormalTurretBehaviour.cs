using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTurretBehaviour : TurretBehaviour
{
    [SerializeField] private ParticleSystem[] BulletEffect;

    void Start()
    {
        BulletEffect = GetComponentsInChildren<ParticleSystem>();
    }

    public override void Fire()
    {
        base.StopFiring();
        for (int i = 0; i < BulletEffect.Length; i++)
        {
            if (!BulletEffect[i].isPlaying)
            {
                BulletEffect[i].Play();
            }
        }
    }

    public override void StopFiring()
    {
        for (int i = 0; i < BulletEffect.Length; i++)
        {
            BulletEffect[i].Stop();
        }
    }
}
