using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTemp : MonoBehaviour
{
    [SerializeField] private Transform ObjectToLookAt;

    void Update()
    {
        transform.LookAt(ObjectToLookAt);
    }
}
