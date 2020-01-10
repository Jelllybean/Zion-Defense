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

    public virtual void hideBullet()
    {
        gameObject.SetActive(false);
    }
    public virtual void OnDisable()
    {
        CancelInvoke();
    }

}
