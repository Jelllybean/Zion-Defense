using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private float LivesToTake;
    public int currentWayPoint = 0;
    public float distance;
    private LivesManager livesManager;

    private void Start()
    {
        livesManager = FindObjectOfType<LivesManager>();
    }
    private void OnEnable()
    {
        currentWayPoint = 0;
    }
    void Update()
    {
        Vector3 pos = new Vector3(wayPoints[currentWayPoint].position.x, transform.position.y, wayPoints[currentWayPoint].position.z);
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        distance = Vector3.Distance(transform.position, pos);
        if(distance < 0.01f)
        {
            currentWayPoint++;
        }
        if (currentWayPoint >= wayPoints.Length)
        {
            gameObject.SetActive(false);
            livesManager.LivesCount -= LivesToTake;
        }
    }
}
