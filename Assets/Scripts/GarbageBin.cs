using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : MonoBehaviour
{
    [SerializeField] private Transform turretPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CanPickup" || other.gameObject.tag == "CanRotate")
        {
            print("1");
            other.gameObject.transform.position = turretPoint.position;
            other.gameObject.transform.rotation = Quaternion.identity;
        }
        if (other.gameObject.tag == "GameController")
        {
            print("2");
            GrabObjects grab = other.gameObject.GetComponent<GrabObjects>();
            grab.fixedJoint.connectedBody = null;
            grab.OutlineObject.gameObject.SetActive(false);
            grab.CurrentObject.ActiveHand = null;
            grab.CurrentObject = null;
        }
    }
}
