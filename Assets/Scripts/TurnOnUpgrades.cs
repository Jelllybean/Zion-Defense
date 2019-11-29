using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TurnOnUpgrades : MonoBehaviour
{
    public SteamVR_Action_Boolean TriggerAction = null;
    public SteamVR_Behaviour_Pose Pose = null;

    [SerializeField] private GameObject UpgradeMenu;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            Pose = other.gameObject.transform.parent.GetComponent<SteamVR_Behaviour_Pose>();
            if (TriggerAction.GetStateDown(Pose.inputSource))
            {
                if (UpgradeMenu.activeInHierarchy)
                    UpgradeMenu.SetActive(false);
                else if (!UpgradeMenu.activeInHierarchy)
                    UpgradeMenu.SetActive(true);
            }
        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    print(collision.gameObject.name);
    //    if (collision.gameObject.CompareTag("GameController"))
    //    {
    //        print("shdhsdf");
    //        Pose = collision.gameObject.GetComponent<SteamVR_Behaviour_Pose>();
    //        if (TriggerAction.GetStateDown(Pose.inputSource))
    //        {
    //            if (UpgradeMenu.activeSelf)
    //                UpgradeMenu.SetActive(false);
    //            if (!UpgradeMenu.activeSelf)
    //                UpgradeMenu.SetActive(true);
    //        }
    //    }
    //}
}
