﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RoundSystem : MonoBehaviour
{
    private GameObject[] Enemys = new GameObject[200];
    private ActivateButton activateButton;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int[] EnemysToSpawn = new int[10];
    [SerializeField] private int CurrentRound = -1;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Transform Table;
    [SerializeField] private DamageScript[] damageScript = new DamageScript[200];
    private float HealthMultiplier = 1.2f;
    private bool canProgress = true;

    void Start()
    {
        activateButton = GetComponent<ActivateButton>();
        activateButton.ButtonPressed += CheckNextRound;
        for (int i = 0; i < Enemys.Length; i++)
        {
            Enemys[i] = Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity);
            damageScript[i] = Enemys[i].GetComponent<DamageScript>();
            Enemys[i].transform.SetParent(Table);
            Enemys[i].SetActive(false);
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    for (int i = 0; i < Enemys.Length; i++)
        //    {
        //        if (Enemys[i].activeSelf)
        //        {
        //            canProgress = false;
        //            break;
        //        }
        //        else
        //            canProgress = true;
        //    }
        //    if (canProgress)
        //    {
        //        StartCoroutine(NextRound());
        //        CurrentRound++;
        //    }
        //}
    }

    public void CheckNextRound()
    {
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i].activeSelf)
            {
                canProgress = false;
                break;
            }
            else
                canProgress = true;
        }
        if (canProgress)
        {
            CurrentRound++;
            for (int i = 0; i < damageScript.Length; i++)
            {
                HealthMultiplier *= damageScript[i].HealthPoints;
            }
            //HealthMultiplier *= Health;
            StartCoroutine(NextRound());
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "GameController")
    //    {
    //        for (int i = 0; i < Enemys.Length; i++)
    //        {
    //            if (Enemys[i].activeSelf)
    //            {
    //                canProgress = false;
    //                break;
    //            }
    //            else
    //                canProgress = true;
    //        }
    //        if (canProgress)
    //        {
    //            StartCoroutine(NextRound());
    //            CurrentRound++;
    //        }
    //    }
    //}
    private IEnumerator NextRound()
    {
        for (int i = 0; i < EnemysToSpawn[CurrentRound]; i++)
        {
            yield return new WaitForSeconds(1f);
            Enemys[i].SetActive(true);
            Enemys[i].transform.position = SpawnPoint.position;
        }
    }
}
