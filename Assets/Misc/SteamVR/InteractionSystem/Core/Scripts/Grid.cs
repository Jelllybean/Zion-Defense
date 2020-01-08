using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private float GridSize = 0f;
        public bool canPlace = true;
        public bool gridActive;

        public float Size { get { return Size; } }

        public Vector3 GetNearestPointOnGrid(Vector3 position)
        {
            // TODO verplaats deze check naar GrabObjects
            if (gridActive)
            {
                position -= transform.position;
        
                int xCount = Mathf.RoundToInt(position.x / GridSize);
                int yCount = Mathf.RoundToInt(position.y / GridSize);
                int zCount = Mathf.RoundToInt(position.z / GridSize);
        
                Vector3 result = new Vector3((float)xCount * GridSize, 0, (float)zCount * GridSize);
        
                result += transform.position;
                return result;
            }
            else
            {
                return Vector3.zero;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("CanPickup") || other.gameObject.CompareTag("CanRotate"))
            {
                gridActive = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("CanPickup") || other.gameObject.CompareTag("CanRotate"))
            {
                gridActive = false;
            }
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
}
