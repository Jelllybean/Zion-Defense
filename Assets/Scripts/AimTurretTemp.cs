﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurretTemp : MonoBehaviour
{
    public Transform objectToFollow;
    private RaycastHit hit;
    void Update()
    {
        int layerMask = 1 << 10;
        //layerMask = ~layerMask;
        Physics.Raycast(transform.position, transform.forward, out hit, 1000);

        objectToFollow.position = hit.point;

        //sphere.position = hit.point;
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
    }
}
