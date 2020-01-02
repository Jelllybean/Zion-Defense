using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TurretWheel : MonoBehaviour
{
    public SteamVR_Action_Boolean m_TouchpadAction = null;
    public SteamVR_Action_Vector2 m_TouchPadPos = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    public SteamVR_Input_Sources m_HandType;

    public Vector2 m_TrackPad;

    void Start()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Update()
    {
        m_TrackPad = m_TouchPadPos[m_HandType].axis;
        if (m_TouchpadAction.GetStateDown(m_Pose.inputSource))
        {
            print("touchpad ingedrukt");
        }
    }
}
