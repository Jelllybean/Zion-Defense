using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UpgradeRadius : MonoBehaviour
{
    public SteamVR_Action_Boolean TriggerAction = null;
    private SteamVR_Behaviour_Pose Pose = null;

    [SerializeField] private TurretUpgradeSystem UpgradeSystem;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            Pose = other.GetComponent<SteamVR_Behaviour_Pose>();
            if (TriggerAction.GetStateDown(Pose.inputSource))
            {
                UpgradeSystem.UpgradeRange();
            }
        }
    }
}
