using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
    }
    private void OnEnable()
    {
        trail.Clear();
        Invoke("hideBullet", 2.0f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

}
