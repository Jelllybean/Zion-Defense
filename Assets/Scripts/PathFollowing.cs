using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private float LivesToTake;
    public int currentWayPoint = 0;
    public List<float> distance = new List<float>();
    public float m_EntireDistance;
    private LivesManager livesManager;

    private void Awake()
    {
        livesManager = FindObjectOfType<LivesManager>();
        for (int i = 0; i < distance.Count; i++)
        {
            if (i + 1 != distance.Count)
                distance[i] += Vector3.Distance(wayPoints[i].position, wayPoints[i + 1].position);
        }
    }
    private void OnEnable()
    {
        currentWayPoint = 0;
    }
    void Update()
    {
        Vector3 pos = new Vector3(wayPoints[currentWayPoint].position.x, transform.position.y, wayPoints[currentWayPoint].position.z);
        transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        distance[currentWayPoint] = Vector3.Distance(transform.position, pos);
        m_EntireDistance = distance.Sum();
        if (distance[currentWayPoint] < 0.01f)
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
