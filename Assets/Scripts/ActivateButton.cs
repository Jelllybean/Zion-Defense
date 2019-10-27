using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    public event System.Action ButtonPressed;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Button")
    //    {
    //        ButtonPressed?.Invoke();
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            ButtonPressed?.Invoke();
        }
    }
}