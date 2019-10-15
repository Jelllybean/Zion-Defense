using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacementCheck : MonoBehaviour
{
    private Grid grid;

    void Start()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Path")
        {
            grid.canPlace = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Path")
        {
            grid.canPlace = true;
        }
    }
}
