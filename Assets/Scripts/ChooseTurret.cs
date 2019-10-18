using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ChooseTurret : MonoBehaviour
{
    public AimTurretTemp AimTurret;
    public SteamVR_Action_Boolean GrabAction = null;
    private RaycastHit hit;
    public SteamVR_Input_Sources handType;

    private void Start()
    {
        //AimTurret = GetComponent<AimTurretTemp>();
    }
    void Update()
    {
        int layerMask = 1 << 13;
        //layerMask = ~layerMask;
        Physics.Raycast(transform.position, transform.forward, out hit, 1000, layerMask);
        if (GrabAction.GetStateDown(handType))
        {
            if(hit.collider)
            {
                if (hit.collider.tag == "Turret")
                {
                    hit.collider.gameObject.GetComponent<TurretBehaviour>().enabled = false;
                    MuzzleEffect muzzle = hit.collider.gameObject.GetComponent<MuzzleEffect>();
                    muzzle.enabled = true;
                    muzzle.handType = handType;
                    muzzle.lookAt.ObjectToLookAt = AimTurret.objectToFollow;
                    muzzle.AddStates();
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
    }
}
