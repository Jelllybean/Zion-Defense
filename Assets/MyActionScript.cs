using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MyActionScript : MonoBehaviour
{

    public SteamVR_Action_Boolean FireTurret;

    public SteamVR_Input_Sources handType;

    public GameObject Sphere;

    void Start()
    {
        FireTurret.AddOnStateDownListener(TriggerDown, handType);
        FireTurret.AddOnStateUpListener(TriggerUp, handType);
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger is up");
        Sphere.SetActive(false);
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger is Down");
        Sphere.SetActive(true);
    }
}
