using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTemp : MonoBehaviour
{
    public Transform ObjectToLookAt;

    void Update()
    {
        transform.LookAt(ObjectToLookAt);
    }
}
