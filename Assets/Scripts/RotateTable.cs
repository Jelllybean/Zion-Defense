using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTable : MonoBehaviour
{
    public Transform Rotater;

    void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x, Rotater.rotation.y, transform.rotation.y, transform.rotation.z);
    }
}
