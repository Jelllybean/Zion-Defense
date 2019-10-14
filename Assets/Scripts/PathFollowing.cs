using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed = 0.3f;
    private int currentWayPoint = 0;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].position, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, wayPoints[currentWayPoint].position);
        if(distance < 0.01f)
        {
            currentWayPoint++;
        }
    }
}
