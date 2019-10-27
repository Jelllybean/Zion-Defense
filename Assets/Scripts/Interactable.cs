using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private Vector3 Offset = Vector3.zero;
    public bool isTurret = false;
    [HideInInspector] public GrabObjects ActiveHand = null;

    public virtual void Action()
    {
        print("Action");
    }

    public void ApplyOffset(Transform hand)
    {
        transform.SetParent(hand);
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Offset;
        transform.SetParent(null);
    }
}
