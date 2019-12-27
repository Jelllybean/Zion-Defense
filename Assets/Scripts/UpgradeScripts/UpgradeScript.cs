using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UpgradeScript : MonoBehaviour
{

    public SteamVR_Action_Boolean TriggerAction = null;
    private SteamVR_Behaviour_Pose Pose = null;

    public Vector2 m_UpgradeProcess;

    public GameObject[] m_LeftPath;
    public GameObject[] m_RightPath;

    public Transform sphere;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            if (!Pose)
            {
                Pose = other.gameObject.transform.parent.GetComponent<SteamVR_Behaviour_Pose>();
                if (TriggerAction.GetStateDown(Pose.inputSource))
                {
                    if (m_UpgradeProcess.x == 0)
                        Upgrade1_0();
                    if (m_UpgradeProcess.x == 1)
                        Upgrade2_0();
                    if (m_UpgradeProcess.x == 2)
                        Upgrade3_0();
                    if (m_UpgradeProcess.x == 2)
                        Upgrade4_0();

                    if (m_UpgradeProcess.y == 0)
                        Upgrade0_1();
                    if (m_UpgradeProcess.y == 1)
                        Upgrade0_2();
                    if (m_UpgradeProcess.y == 2)
                        Upgrade0_3();
                    if (m_UpgradeProcess.y == 2)
                        Upgrade0_4();
                }
            }
        }
    }

    private void Update()
    {
        if (m_LeftPath.Length > 0)
        {
            if (m_UpgradeProcess.x == 0)
            {
                m_LeftPath[0].SetActive(true);
                m_LeftPath[1].SetActive(false);
                m_LeftPath[2].SetActive(false);
                m_LeftPath[3].SetActive(false);
            }
            if (m_UpgradeProcess.x == 1)
            {
                m_LeftPath[0].SetActive(false);
                m_LeftPath[1].SetActive(true);
                m_LeftPath[2].SetActive(false);
                m_LeftPath[3].SetActive(false);
            }
            if (m_UpgradeProcess.x == 2)
            {
                m_LeftPath[0].SetActive(false);
                m_LeftPath[1].SetActive(false);
                m_LeftPath[2].SetActive(true);
                m_LeftPath[3].SetActive(false);
            }
            if (m_UpgradeProcess.x == 3)
            {
                m_LeftPath[0].SetActive(false);
                m_LeftPath[1].SetActive(false);
                m_LeftPath[2].SetActive(false);
                m_LeftPath[3].SetActive(true);
            }
        }
        if (m_RightPath.Length > 0)
        {
            if (m_UpgradeProcess.y == 0)
            {
                m_RightPath[0].SetActive(true);
                m_RightPath[1].SetActive(false);
                m_RightPath[2].SetActive(false);
                m_RightPath[3].SetActive(false);
            }
            if (m_UpgradeProcess.y == 1)
            {
                m_RightPath[0].SetActive(false);
                m_RightPath[1].SetActive(true);
                m_RightPath[2].SetActive(false);
                m_RightPath[3].SetActive(false);
            }
            if (m_UpgradeProcess.y == 2)
            {
                m_RightPath[0].SetActive(false);
                m_RightPath[1].SetActive(false);
                m_RightPath[2].SetActive(true);
                m_RightPath[3].SetActive(false);
            }
            if (m_UpgradeProcess.y == 3)
            {
                m_RightPath[0].SetActive(false);
                m_RightPath[1].SetActive(false);
                m_RightPath[2].SetActive(false);
                m_RightPath[3].SetActive(true);
            }
        }
    }

    public virtual void Upgrade1_0()
    {
        m_UpgradeProcess.x++;
    }

    public virtual void Upgrade2_0()
    {
        m_UpgradeProcess.x++;
    }

    public virtual void Upgrade3_0()
    {
        m_UpgradeProcess.x++;
    }

    public virtual void Upgrade4_0()
    {
        m_UpgradeProcess.x++;
    }


    public virtual void Upgrade0_1()
    {
        m_UpgradeProcess.y++;
    }

    public virtual void Upgrade0_2()
    {
        m_UpgradeProcess.y++;
    }
    public virtual void Upgrade0_3()
    {
        m_UpgradeProcess.y++;
    }
    public virtual void Upgrade0_4()
    {
        m_UpgradeProcess.y++;
    }
}
