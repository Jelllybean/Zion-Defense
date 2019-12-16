using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UpgradeScript : MonoBehaviour
{
    public enum UpgradeProgress
    {
        LeftOne,
        LeftTwo,
        LeftThree,
        LeftFour,
        RightOne,
        RightTwo,
        RightThree,
        RightFour
    }

    public SteamVR_Action_Boolean TriggerAction = null;
    private SteamVR_Behaviour_Pose Pose = null;

    public Vector2 m_UpgradeProcess;
    public UpgradeProgress m_UpgradeProgress;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            if (!Pose)
            {
                Pose = other.gameObject.transform.parent.GetComponent<SteamVR_Behaviour_Pose>();
                if (TriggerAction.GetStateDown(Pose.inputSource))
                {
                    switch(m_UpgradeProgress)
                    {
                        case UpgradeProgress.LeftOne:
                            Upgrade1_0();
                            break;
                        case UpgradeProgress.LeftTwo:
                            Upgrade2_0();
                            break;

                    }
                }
            }
        }
    }

    public void Upgrade1_0()
    {
        m_UpgradeProcess.x++;
    }

    public void Upgrade2_0()
    {
        m_UpgradeProcess.x++;
    }

    public void Upgrade3_0()
    {
        m_UpgradeProcess.x++;
    }

    public void Upgrade4_0()
    {
        m_UpgradeProcess.x++;
    }


    public void Upgrade0_1()
    {
        m_UpgradeProcess.y++;
    }

    public void Upgrade0_2()
    {
        m_UpgradeProcess.y++;
    }
    public void Upgrade0_3()
    {
        m_UpgradeProcess.y++;
    }
    public void Upgrade0_4()
    {
        m_UpgradeProcess.y++;
    }
}
