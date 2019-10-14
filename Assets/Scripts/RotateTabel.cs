using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotateTabel : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabAction = null;
    private SteamVR_Behaviour_Pose Pose = null;
    [SerializeField] private Transform Table;

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "TurnLeft")
        {
            if (GrabAction.GetState(Pose.inputSource))
            {
                RotateLeft();
            }
        }
        if (other.gameObject.name == "TurnRight")
        {
            if (GrabAction.GetState(Pose.inputSource))
            {
                RotateRight();
            }
        }
    }
    //ja ik WEET dat deze niet kloppen laat me met rust
    public void RotateLeft()
    {
        Table.Rotate(Vector3.up);
    }
    public void RotateRight()
    {
        Table.Rotate(Vector3.down);
    }
}
