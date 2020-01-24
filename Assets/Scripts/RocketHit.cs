using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour
{
    [SerializeField] private GameObject m_ParticlePrefab;
    private ParticleSystem m_ExplosionParticle;
    private Transform m_ExplosionParticleTransform;

    private DisableRockets m_DisableRockets;

    [SerializeField] private float m_Radius;

    private void Start()
    {
        m_DisableRockets = gameObject.GetComponent<DisableRockets>();
        GameObject _prefab = Instantiate(m_ParticlePrefab, transform.position, Quaternion.identity);
        m_ExplosionParticle = _prefab.GetComponent<ParticleSystem>();
        m_ExplosionParticleTransform = _prefab.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            SetExplosion();
        }
    }

    private void SetExplosion()
    {
        m_ExplosionParticleTransform.position = transform.position;
        m_ExplosionParticle.Play();
        Collider[] _hitColliders = Physics.OverlapSphere(transform.position, m_Radius, 1 << 10);
        for (int i = 0; i < _hitColliders.Length; i++)
        {
            float proximity = (transform.position - _hitColliders[i].transform.position).magnitude;
            float effect = 1 - proximity;
            print(_hitColliders[i].name + ": " + proximity);
            //print(effect);
            //float distance = Vector3.Distance(transform.position, _hitColliders[i].transform.position);
            //print(distance);
            _hitColliders[i].GetComponent<DamageScript>().HealthPoints -= effect * 90;
        }
        m_DisableRockets.HideRocket();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_Radius);
    }
}
