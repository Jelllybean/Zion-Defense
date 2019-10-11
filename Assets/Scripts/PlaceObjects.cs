using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlaceObjects : MonoBehaviour
{

    public SteamVR_Action_Boolean FireTurret;
    public SteamVR_Input_Sources handType;
    private Grid grid;
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }

    private void Update()
    {
        //Ray ray = Physics.Raycast(transform.position, transform.forward, out hit, 1000);
        //if (Physics.Raycast(ray, out hit)) ;
        //RaycastHit hitInfo;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            PlaceObjectNear(hit.point);
        }
    }
    private void PlaceObjectNear(Vector3 nearPoint)
    {
        Vector3 finalPosition = grid.GetNearestPointOnGrid(nearPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;
    }
}
