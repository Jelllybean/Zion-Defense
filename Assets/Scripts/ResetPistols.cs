using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPistols : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("CanPickup"))
        {
            other.gameObject.transform.position = transform.position;
        }
    }
}
