using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DisableBullet", 2f);
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
