using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.current.transform);
    }
}
