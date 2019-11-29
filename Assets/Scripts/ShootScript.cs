using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    [SerializeField] private float bulletspeed = 500;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullet_Emitter;
    private Rigidbody[] rigidBodies = new Rigidbody[20];
    //private Interactable interactable;
    private float timer;

    List<GameObject> bulletList;
	void Start ()
    {
        //interactable = GetComponent<Interactable>();
        //interactable.PerformAction += Shoot;
        bulletList = new List<GameObject>();
        for(int i = 0; i < 20; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            rigidBodies[i] = objBullet.GetComponent<Rigidbody>();
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
	}
	public void Shoot()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = bullet_Emitter.position;
                bulletList[i].transform.rotation = bullet_Emitter.rotation;
                bulletList[i].SetActive(true);
                rigidBodies[i].velocity = Vector3.zero;
                rigidBodies[i].AddForce(rigidBodies[i].transform.forward * bulletspeed);
                break;
            }
        }
    }
}
