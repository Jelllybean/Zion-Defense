using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform object1;
    public Transform object2;

    void Update()
    {
        float distance = Vector3.Distance(object1.position, object2.position);
        print(distance);
    }
}
