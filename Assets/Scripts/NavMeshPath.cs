using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPath : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(target.position);
    }

    
    void Update()
    {
        Debug.Log(navMeshAgent.remainingDistance);
    }
}
