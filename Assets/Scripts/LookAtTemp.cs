using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTemp : MonoBehaviour
{
    public Transform ObjectToLookAt;

    private void Start()
    {
        ObjectToLookAt = Camera.main.transform;
    }
    void Update()
    {
        transform.LookAt(ObjectToLookAt);
    }
}
