using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClosestEnemy : MonoBehaviour
{
    public List<PathFollowing> AllEnemys = new List<PathFollowing>();
    public int currentHighestWayPoint;
    public float currentLowestDistance;
    public int[] wayPointArray;
    public float[] distanceArray;

    private void Start()
    {
    }

    void Update()
    {
        for (int i = 0; i < AllEnemys.Count; i++)
        {
            wayPointArray[i] = AllEnemys[i].currentWayPoint;
            if(AllEnemys[i].gameObject.activeInHierarchy)
            {
                distanceArray[i] = AllEnemys[i].distance;
            }
        }
        currentHighestWayPoint = Mathf.Max(wayPointArray);
        currentLowestDistance = Mathf.Max(distanceArray);
        //for (int i = 0; i < aaaaaah.Length; i++)
        //{
        //    currentHighestWayPoint = Mathf.Max(aaaaaah);
        //}
        //for (int i = 0; i < AllEnemys.Count; i++)
        //{
        //    if (AllEnemys[i].gameObject.activeInHierarchy)
        //    {
        //
        //    }
        //}
    }
}
