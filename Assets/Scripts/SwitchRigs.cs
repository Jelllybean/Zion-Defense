using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRigs : MonoBehaviour
{
    [SerializeField] private GameObject BigRig;
    [SerializeField] private GameObject SmallRig;

    public void SwitchRigFunction()
    {
        if(BigRig.activeSelf)
        {
            SmallRig.SetActive(true);
            BigRig.SetActive(false);
        }
        else if (SmallRig.activeSelf)
        {
            SmallRig.SetActive(false);
            BigRig.SetActive(true);
        }
    }
}
