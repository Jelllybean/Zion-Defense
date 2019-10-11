using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfTheSwarm : MonoBehaviour
{
    public Transform[] boidPrefab;
    public int swarmCount = 100;
    public int SpawnRadius;

    void Awake()
    {
        for(int i = 0; i < swarmCount; i++)
        {
            Instantiate(boidPrefab[Random.Range(0, boidPrefab.Length)], Random.insideUnitSphere * SpawnRadius, Quaternion.identity);
        }
    }
}
