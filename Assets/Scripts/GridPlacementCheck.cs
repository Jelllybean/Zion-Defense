using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class GridPlacementCheck : MonoBehaviour
    {
        private Grid grid;
        public Renderer Rend;

        void Start()
        {
            grid = FindObjectOfType<Grid>();
            Rend.sharedMaterial.SetColor("_OutlineColor", new Color(0, 253, 255, 255));
        }

        private void Update()
        {
            if (!grid.canPlace)
            {
                Rend.sharedMaterial.SetColor("_OutlineColor", Color.red);
            }
            if (grid.canPlace)
            {
                Rend.sharedMaterial.SetColor("_OutlineColor", new Color(0, 253, 255, 255));
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Path"))
            {
                grid.canPlace = false;
            }
            else
            {
                grid.canPlace = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Path"))
            {
                grid.canPlace = true;
            }
        }
    }
}
