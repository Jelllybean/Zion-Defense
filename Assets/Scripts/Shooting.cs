using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Interactable
{
    [SerializeField]
    private GameObject Kogel;
    [SerializeField]
    private Transform Bullet_Emitter;
    [SerializeField]
    private float Bullet_force;

    //public override void Action()
    //{
    //    GameObject Temporary_Bullet_Handler;
    //    Temporary_Bullet_Handler = Instantiate(Kogel, Bullet_Emitter.position, Bullet_Emitter.rotation) as GameObject;
    //    
    //    Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 0);
    //    
    //    Rigidbody Temporary_RigidBody;
    //    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
    //    
    //    Temporary_RigidBody.AddForce(transform.forward * Bullet_force);
    //    
    //    Destroy(Temporary_Bullet_Handler, 5f);
    //    //timer = 0;
    //}
}
