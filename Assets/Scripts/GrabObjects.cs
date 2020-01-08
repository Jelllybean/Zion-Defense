using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class GrabObjects : MonoBehaviour
    {
        public SteamVR_Action_Boolean TriggerAction = null;
        public SteamVR_Action_Boolean TouchPadAction = null;

        private SteamVR_Behaviour_Pose Pose = null;
        public FixedJoint fixedJoint = null;

        public Interactable2 CurrentObject = null;
        public List<Interactable2> ContactInteractables = new List<Interactable2>();
        private Grid gridPosition;
        public Transform OutlineObject;
        private TotalMoney MoneyCounter;
        [SerializeField] private GameObject TurretPrefab;
        [SerializeField] private Transform Table;
        [SerializeField] private Transform RotatingPlane;
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
            if (TriggerAction.GetStateDown(Pose.inputSource))
            {
                if (CurrentObject)
                {
                    CurrentObject.Action();
                    return;
                }
                Pickup();
            }
            // Up
            if (TouchPadAction.GetStateDown(Pose.inputSource))
            {
                Drop();
            }
            if (CurrentObject)
            {
                if (CurrentObject.gameObject.CompareTag("CanPickup"))
                {
                    //OutlineObject.transform.position = gridPosition.GetNearestPointOnGrid(CurrentObject.transform.position);
                }
            }
            if (CurrentObject)
            {
                //if (gridPosition.gridActive && CurrentObject.isTurret)
                //{
                //    OutlineObject.gameObject.SetActive(true);
                //}
                //else
                //{
                //    OutlineObject.gameObject.SetActive(false);
                //}
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("CanPickup") && !other.gameObject.CompareTag("CanRotate") && !other.gameObject.CompareTag("Turret"))
                return;

            ContactInteractables.Add(other.gameObject.GetComponent<Interactable2>());
        }
        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("CanPickup") && !other.gameObject.CompareTag("CanRotate") && !other.gameObject.CompareTag("Turret"))
                return;

            ContactInteractables.Remove(other.gameObject.GetComponent<Interactable2>());
        }

        private void Pickup()
        {
            // Get nearest
            CurrentObject = getNearestInteractable();
            //null check
            if (!CurrentObject)
                return;

            //check for upgrade menu
            if (CurrentObject.gameObject.CompareTag("Turret"))
            {
                TurretBehaviour turret = CurrentObject.GetComponent<TurretBehaviour>();
                if (turret.UpgradeMenu.activeInHierarchy)
                {
                    turret.UpgradeMenu.SetActive(false);
                }
                else if (!turret.UpgradeMenu.activeInHierarchy)
                {
                    turret.UpgradeMenu.SetActive(true);
                }
                DropRotate();
                return;
            }

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
            CurrentObject.ApplyOffset(transform);
            //CurrentObject.transform.position = transform.position;

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
                if (CurrentObject.gameObject.CompareTag("CanPickup") && !CurrentObject.isTurret)
                    DropNormal();
                else if (CurrentObject.gameObject.CompareTag("CanPickup") && CurrentObject.isTurret)
                    PlaceTurret();
                else if (CurrentObject.gameObject.CompareTag("CanRotate"))
                    DropRotate();
            }
        }

        private void PlaceTurret()
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
                if (MoneyCounter.totalMoneyCounter >= 300)
                {
                    //GameObject newTower = Instantiate(TurretPrefab, gridPosition.GetNearestPointOnGrid(CurrentObject.transform.position),
                    //    gridPosition.transform.rotation);
                    //newTower.transform.SetParent(Table.transform);
                    //MoneyCounter.totalMoneyCounter -= 300;
                    //CurrentObject.transform.position = turretPoint.position;
                    //CurrentObject.transform.rotation = Quaternion.identity;
                    //CurrentObject.transform.parent = RotatingPlane;
                }
                else
                {
                    CurrentObject.transform.position = turretPoint.position;
                    CurrentObject.transform.rotation = Quaternion.identity;
                }
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
        private void DropNormal()
        {
            // Null check
            if (!CurrentObject)
                return;

            //Apply velocity
            Rigidbody targetBody = CurrentObject.GetComponent<Rigidbody>();
            targetBody.velocity = Pose.GetVelocity();
            targetBody.angularVelocity = Pose.GetAngularVelocity();

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

        private Interactable2 getNearestInteractable()
        {
            Interactable2 nearest = null;
            float minDistance = float.MaxValue;
            float distance = 0f;

            foreach (Interactable2 interactable in ContactInteractables)
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
}