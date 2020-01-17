using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBullet : MonoBehaviour
{
    public Transform m_BulletEmitter;
    private void OnEnable()
    {
        Invoke("DisableBullet", 2f);
        transform.position = m_BulletEmitter.position;
        transform.rotation = m_BulletEmitter.rotation;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
