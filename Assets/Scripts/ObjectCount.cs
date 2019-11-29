using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCount : MonoBehaviour
{
    public GameObject m_NewObject;
    void Start()
    {
        SpawnNewObject();
    }

    private void OnTriggerExit(Collider other)
    {
            SpawnNewObject();
    }

    private void SpawnNewObject()
    {
        GameObject newObject = Instantiate(m_NewObject, transform.position, transform.rotation);
    }
}
