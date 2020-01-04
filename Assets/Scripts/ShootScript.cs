using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ShootScript : MonoBehaviour
{
    //public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_TriggerAction = null;

    private Interactable interactable;

    [SerializeField] private float bulletspeed = 500;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_Emitter;
    private Rigidbody[] rigidBodies = new Rigidbody[20];
    private float timer;

    List<GameObject> bulletList;
    void Start()
    {
        //interactable = GetComponent<Interactable>();
        //interactable.PerformAction += Shoot;
        interactable = GetComponent<Interactable>();
        bulletList = new List<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            rigidBodies[i] = objBullet.GetComponent<Rigidbody>();
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
    }

    private void Update()
    {
        if (interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            if (m_TriggerAction.GetStateDown(hand))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = bullet_Emitter.position;
                bulletList[i].transform.rotation = bullet_Emitter.rotation;
                bulletList[i].SetActive(true);
                rigidBodies[i].velocity = Vector3.zero;
                rigidBodies[i].AddForce(rigidBodies[i].transform.forward * bulletspeed);
                break;
            }
        }
    }
}
