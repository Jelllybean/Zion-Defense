using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TurretWheel : MonoBehaviour
{
    public SteamVR_Action_Boolean m_TouchpadAction = null;
    public SteamVR_Action_Vector2 m_TouchPadPos = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    public SteamVR_Input_Sources m_HandType;

    public Vector2 m_TrackPad;

    public GameObject m_TurretWheelObj;
    public GameObject[] m_TurretPrefabs;

    public SpriteRenderer[] m_TurretWheelParts;

    private Color[] color = new Color[2];

    private TotalMoney m_TotalMoney;
    private Hand m_Hand;

    //[EnumFlags]
    //public Hand.AttachmentFlags attachmentFlags = 0;

    void Start()
    {
        color[0].a = 0.5f;
        color[1].a = 1f;
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Hand = GetComponent<Hand>();
        m_TotalMoney = FindObjectOfType<TotalMoney>();
    }

    void Update()
    {
        m_TrackPad = m_TouchPadPos[m_HandType].axis;
        if (m_TouchpadAction.GetStateDown(m_Pose.inputSource))
        {
            if (!m_TurretWheelObj.activeInHierarchy)
                m_TurretWheelObj.SetActive(true);
            else if (m_TrackPad.x < 0.5f && m_TrackPad.y > 0.5f && m_TotalMoney.totalMoneyCounter >= 300)
            {
                m_TotalMoney.totalMoneyCounter -= 300;
                Instantiate(m_TurretPrefabs[0], transform.position, Quaternion.identity);
                m_TurretWheelObj.SetActive(false);
            }
            else if (m_TrackPad.x > 0.5f && m_TrackPad.y > 0.5f && m_TotalMoney.totalMoneyCounter >= 500)
            {
                m_TotalMoney.totalMoneyCounter -= 500;
                Instantiate(m_TurretPrefabs[1], transform.position, Quaternion.identity);
                m_TurretWheelObj.SetActive(false);
            }
            else if (m_TrackPad.x > 0.5f && m_TrackPad.y < 0.5f)
            {
                m_TurretWheelObj.SetActive(false);
            }
        }

        //Linksboven
        if (m_TrackPad.x < 0.5f && m_TrackPad.y > 0.5f)
        {
            m_TurretWheelParts[0].color = color[1];
            m_TurretWheelParts[1].color = color[0];
            m_TurretWheelParts[2].color = color[0];
            m_TurretWheelParts[3].color = color[0];
        }
        //Linksonder
        if (m_TrackPad.x < 0.5f && m_TrackPad.y < 0.5f)
        {
            m_TurretWheelParts[0].color = color[0];
            m_TurretWheelParts[1].color = color[0];
            m_TurretWheelParts[2].color = color[1];
            m_TurretWheelParts[3].color = color[0];
        }
        //Rechtsboven
        if (m_TrackPad.x > 0.5f && m_TrackPad.y > 0.5f)
        {
            m_TurretWheelParts[0].color = color[0];
            m_TurretWheelParts[1].color = color[1];
            m_TurretWheelParts[2].color = color[0];
            m_TurretWheelParts[3].color = color[0];
        }
        //Rechtsonder
        if (m_TrackPad.x > 0.5f && m_TrackPad.y < 0.5f)
        {
            m_TurretWheelParts[0].color = color[0];
            m_TurretWheelParts[1].color = color[0];
            m_TurretWheelParts[2].color = color[0];
            m_TurretWheelParts[3].color = color[1];
        }
    }
}
