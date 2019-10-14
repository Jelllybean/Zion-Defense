using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabObjects : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabAction = null;

    private SteamVR_Behaviour_Pose Pose = null;
    public FixedJoint fixedJoint = null;

    public Interactable CurrentObject = null;
    public List<Interactable> ContactInteractables = new List<Interactable>();
    private Grid gridPosition;
    public Transform OutlineObject;
    private TotalMoney MoneyCounter;
    [SerializeField] private GameObject TurretPrefab;
    [SerializeField] private Transform Table;
    [SerializeField] private Transform turretPoint;

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        fixedJoint = GetComponent<FixedJoint>();
        gridPosition = FindObjectOfType<Grid>();
        MoneyCounter = FindObjectOfType<TotalMoney>();
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
        if (CurrentObject)
        {
            if (CurrentObject.gameObject.CompareTag("CanPickup"))
            {
                OutlineObject.transform.position = gridPosition.GetNearestPointOnGrid(CurrentObject.transform.position);
            }
        }
        if (gridPosition.gridActive)
        {
            OutlineObject.gameObject.SetActive(true);
        }
        else
        {
            OutlineObject.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("CanPickup") && !other.gameObject.CompareTag("CanRotate"))
            return;

        ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("CanPickup") && !other.gameObject.CompareTag("CanRotate"))
            return;

        ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
    }

    private void Pickup()
    {
        // Get nearest
        CurrentObject = getNearestInteractable();
        //null check
        if (!CurrentObject)
            return;
        OutlineObject.gameObject.SetActive(true);
        if (CurrentObject.gameObject.CompareTag("CanPickup"))
        {
            PickupNormal();
        }
        else if (CurrentObject.gameObject.CompareTag("CanRotate"))
        {
            Rotate();
        }
    }

    private void PickupNormal()
    {
        // already held check
        if (CurrentObject.ActiveHand)
            CurrentObject.ActiveHand.Drop();

        if (!CurrentObject)
            return;
        // positoning
        CurrentObject.transform.position = transform.position;

        // attach 
        Rigidbody targetBody = CurrentObject.GetComponent<Rigidbody>();
        fixedJoint.connectedBody = targetBody;

        // set active hand
        CurrentObject.ActiveHand = this;
    }

    private void Rotate()
    {
        // already held check
        if (CurrentObject.ActiveHand)
            CurrentObject.ActiveHand.Drop();

        // attach 
        Rigidbody targetBody = CurrentObject.GetComponent<Rigidbody>();
        fixedJoint.connectedBody = targetBody;

        // set active hand
        CurrentObject.ActiveHand = this;
    }

    private void Drop()
    {
        if (CurrentObject)
        {
            OutlineObject.gameObject.SetActive(false);
            if (CurrentObject.gameObject.CompareTag("CanPickup"))
                DropNormal();
            else if (CurrentObject.gameObject.CompareTag("CanRotate"))
                DropRotate();
        }
    }

    private void DropNormal()
    {
        // Null check
        if (!CurrentObject)
            return;
        //Apply velocity
        //Rigidbody targetBody = CurrentObject.GetComponent<Rigidbody>();
        //targetBody.velocity = Pose.GetVelocity();
        //targetBody.angularVelocity = Pose.GetAngularVelocity();
        if (gridPosition.gridActive && gridPosition.canPlace)
        {
            GameObject newTower = Instantiate(TurretPrefab, gridPosition.GetNearestPointOnGrid(CurrentObject.transform.position), 
                gridPosition.transform.rotation); 
            newTower.transform.SetParent(Table.transform);
            MoneyCounter.totalMoneyCounter -= 300;
            CurrentObject.transform.position = turretPoint.position;
            CurrentObject.transform.rotation = Quaternion.identity;
        }
        else
        {
            return;
        }

        // Detach
        fixedJoint.connectedBody = null;
        // Clear
        CurrentObject.ActiveHand = null;
        CurrentObject = null;
    }
    private void DropRotate()
    {
        // Null check
        if (!CurrentObject)
            return;

        // Detach
        fixedJoint.connectedBody = null;
        // Clear
        CurrentObject.ActiveHand = null;
        CurrentObject = null;
    }

    private Interactable getNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0f;

        foreach (Interactable interactable in ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
