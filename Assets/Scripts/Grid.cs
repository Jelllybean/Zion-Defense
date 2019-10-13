using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private float GridSize = 1f;

    public float Size { get { return Size; } }
    
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / GridSize);
        int yCount = Mathf.RoundToInt(position.y / GridSize);
        int zCount = Mathf.RoundToInt(position.z / GridSize);

        Vector3 result = new Vector3((float)xCount * GridSize, (float)yCount * GridSize, (float)zCount * GridSize);

        result += transform.position;
        return result;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    for (float i = 0; i < 40; i += GridSize)
    //    {
    //        for (float x = 0; x < 40; x += GridSize)
    //        {
    //            var point = GetNearestPointOnGrid(new Vector3(i, 0f, x));
    //            Gizmos.DrawSphere(point, 0.1f);
    //        }
    //    }
    //}
}
