using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RotateTabel : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabAction = null;
    private SteamVR_Behaviour_Pose Pose = null;
    [SerializeField] private Transform Table;

    public bool m_TurnRight = true;

    private void Awake()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            if (!Pose)
            {
                Pose = other.gameObject.GetComponentInParent<SteamVR_Behaviour_Pose>();
            }
            if (GrabAction.GetState(Pose.inputSource))
            {
                if (m_TurnRight)
                    RotateRight();
                else
                    RotateLeft();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
            Pose = null;
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
