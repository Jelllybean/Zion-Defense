using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MuzzleEffect : MonoBehaviour
{
    public SteamVR_Action_Boolean FireTurret;

    public SteamVR_Input_Sources handType;


    //[SerializeField] private GameObject muzzleFlash;
    //[SerializeField] private RaycastDamage rayCastDamage;
    public LookAtTemp lookAt;
    [SerializeField] private ParticleSystem[] MuzzleParticles;
    private SteamVR_TrackedObject trackedObj;
    private float rotation;
    private float timer = 0;
    private bool isFiring = false;

    void Start()
    {
        FireTurret.AddOnStateDownListener(TriggerDown, handType);
        FireTurret.AddOnStateUpListener(TriggerUp, handType);
    }
    public void AddStates()
    {
        FireTurret.AddOnStateDownListener(TriggerDown, handType);
        FireTurret.AddOnStateUpListener(TriggerUp, handType);
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger is Down");
        for (int i = 0; i < MuzzleParticles.Length; i++)
        {
            if (!MuzzleParticles[i].isPlaying)
            {
                MuzzleParticles[i].Play();
            }
        }
        //isFiring = true;
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Trigger is up");
        for (int i = 0; i < MuzzleParticles.Length; i++)
        {
            MuzzleParticles[i].Stop();
        }
        //isFiring = false;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    ActivateMuzzleFlash();
        //}
        //if (isFiring)
        //{
        //    ActivateMuzzleFlash();
        //}
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rotation = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rotation = 1;
        }
        else
        {
            rotation = 0;
        }
        transform.Rotate(transform.rotation.x, rotation, transform.rotation.z);
    }
    private void ActivateMuzzleFlash()
    {
        //if (timer <= 0.04f)
        //{
        //    rayCastDamage.ShootRay();
        //    //muzzleFlash.transform.rotation = new Quaternion(0, Random.Range(0f, 360f), 90, 1);
        //    //muzzleFlash.transform.eulerAngles = new Vector3(Random.Range(0f, 360f), muzzleFlash.transform.eulerAngles.y, muzzleFlash.transform.eulerAngles.z);
        //}
        //else if (timer > 0.1f)
        //{
        //    muzzleFlash.SetActive(false);
        //    Vector3 euler = muzzleFlash.transform.localEulerAngles;
        //    euler.x = Random.Range(0f, 360f);
        //    muzzleFlash.transform.localEulerAngles = euler;
        //    muzzleFlash.transform.localEulerAngles = new Vector3(Random.Range(0f, 360f), muzzleFlash.transform.localEulerAngles.y, muzzleFlash.transform.localEulerAngles.z);
        //}
        //if (timer >= 0.1f)
        //{
        //    timer = 0;
        //}
        //timer += 1f * Time.deltaTime;
    }

    private void ActivateParticles()
    {
        print("particles staan aan");
    }
    private void DisableParticles()
    {
        print("particles gaan uit");
    }
}
