using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabObjects : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabAction = null;

    private SteamVR_Behaviour_Pose Pose = null;
    private FixedJoint fixedJoint = null;

    private Interactable CurrentObject = null;
    public List<Interactable> ContactInteractables = new List<Interactable>();

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        fixedJoint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        // Down
        if (GrabAction.GetStateDown(Pose.inputSource))
        {
            print(Pose.inputSource + " Trigger Down");
            Pickup();
        }
        // Up
        if (GrabAction.GetStateUp(Pose.inputSource))
        {
            print(Pose.inputSource + " Trigger Up");
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("CanPickup"))
            return;

        ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("CanPickup"))
            return;

        ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }

    public void Pickup()
    {

    }

    public void Drop()
    {

    }

    private Interactable getNearestInteractable()
    {
        return null;
    }
}
