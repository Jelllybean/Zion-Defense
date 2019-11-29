using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
namespace Valve.VR.InteractionSystem
{

    [RequireComponent(typeof(Rigidbody))]
    public class Interactable : MonoBehaviour
    {
        public event System.Action PerformAction;
        [SerializeField] private Vector3 Offset = Vector3.zero;
        public bool isTurret = false;
        [HideInInspector] public GrabObjects ActiveHand = null;

        public void Action()
        {
            PerformAction?.Invoke();
        }

        public void ApplyOffset(Transform hand)
        {
            transform.SetParent(hand);
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Offset;
            transform.SetParent(null);
        }
    }
}
