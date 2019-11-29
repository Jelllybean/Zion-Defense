using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour
{
    [SerializeField] private Transform turretPoint;
    [SerializeField] private Transform plane;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanPickup") || other.gameObject.CompareTag("CanRotate"))
        {
            other.gameObject.transform.position = turretPoint.position;
            other.gameObject.transform.rotation = Quaternion.identity;
            other.gameObject.transform.SetParent(plane);
        }
        if (other.gameObject.CompareTag("GameController"))
        {
            //GrabObjects grab = other.gameObject.GetComponent<GrabObjects>();
            //grab.fixedJoint.connectedBody = null;
            //grab.OutlineObject.gameObject.SetActive(false);
            //grab.CurrentObject.ActiveHand = null;
            //grab.CurrentObject = null;
        }
    }
}
