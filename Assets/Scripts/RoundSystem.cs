﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RoundSystem : MonoBehaviour
{
    private GameObject[] BlueEnemys = new GameObject[100];
    private GameObject[] GreenEnemys = new GameObject[100];
    private GameObject[] FastEnemys = new GameObject[100];
    private GameObject[] TankEnemys = new GameObject[100];
    private GetClosestEnemy ClosestEnemyScript;
    private ActivateButton activateButton;
    [SerializeField] private GameObject BlueEnemy;
    [SerializeField] private GameObject GreenEnemy;
    [SerializeField] private GameObject FastEnemy;
    [SerializeField] private GameObject TankEnemy;
    [SerializeField] private int[] BluesToSpawn = new int[11];
    [SerializeField] private int[] GreensToSpawn = new int[11];
    [SerializeField] private int[] FastsToSpawn = new int[11];
    [SerializeField] private int[] TanksToSpawn = new int[11];
    [SerializeField] private int CurrentRound = -1;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Transform Table;
    private bool canProgress = true;

    //private EnemyManager m_EnemyManager;

    void Start()
    {
        //ClosestEnemyScript = FindObjectOfType<GetClosestEnemy>();
        //activateButton = GetComponent<ActivateButton>();
        //activateButton.ButtonPressed += CheckNextRound;
        //m_EnemyManager = FindObjectOfType<EnemyManager>();
        for (int i = 0; i < BlueEnemys.Length; i++)
        {
            BlueEnemys[i] = Instantiate(BlueEnemy, Vector3.zero, Quaternion.identity);
            BlueEnemys[i].transform.SetParent(Table);
            //m_EnemyManager.m_EnemyPathFollowing.Add(BlueEnemys[i].GetComponent<PathFollowing>());
            BlueEnemys[i].SetActive(false);
        }
        for (int i = 0; i < GreenEnemys.Length; i++)
        {
            GreenEnemys[i] = Instantiate(GreenEnemy, Vector3.zero, Quaternion.identity);
            GreenEnemys[i].transform.SetParent(Table);
            //m_EnemyManager.m_EnemyPathFollowing.Add(GreenEnemys[i].GetComponent<PathFollowing>());
            GreenEnemys[i].SetActive(false);
        }
        for (int i = 0; i < FastEnemys.Length; i++)
        {
            FastEnemys[i] = Instantiate(FastEnemy, Vector3.zero, Quaternion.identity);
            FastEnemys[i].transform.SetParent(Table);
            //m_EnemyManager.m_EnemyPathFollowing.Add(FastEnemys[i].GetComponent<PathFollowing>());
            FastEnemys[i].SetActive(false);
        }
        for (int i = 0; i < TankEnemys.Length; i++)
        {
            TankEnemys[i] = Instantiate(TankEnemy, Vector3.zero, Quaternion.identity);
            TankEnemys[i].transform.SetParent(Table);
            //m_EnemyManager.m_EnemyPathFollowing.Add(TankEnemys[i].GetComponent<PathFollowing>());
            TankEnemys[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < BlueEnemys.Length; i++)
            {
                if (BlueEnemys[i].activeSelf)
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
                StartCoroutine(NextRound());
            }
        }
    }

    public void CheckNextRound()
    {
        for (int i = 0; i < BlueEnemys.Length; i++)
        {
            if (BlueEnemys[i].activeSelf)
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
            StartCoroutine(NextRound());
            canProgress = false;
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
        if (BluesToSpawn[CurrentRound] > 0)
        {
            for (int i = 0; i < BluesToSpawn[CurrentRound]; i++)
            {
                BlueEnemys[i].SetActive(true);
                BlueEnemys[i].transform.position = SpawnPoint.position;
                yield return new WaitForSeconds(1f);
            }
        }
        if (GreensToSpawn[CurrentRound] > 0)
        {
            for (int i = 0; i < GreensToSpawn[CurrentRound]; i++)
            {
                GreenEnemys[i].SetActive(true);
                GreenEnemys[i].transform.position = SpawnPoint.position;
                yield return new WaitForSeconds(1f);
            }
        }
        if (FastsToSpawn[CurrentRound] > 0)
        {
            for (int i = 0; i < FastsToSpawn[CurrentRound]; i++)
            {
                FastEnemys[i].SetActive(true);
                FastEnemys[i].transform.position = SpawnPoint.position;
                yield return new WaitForSeconds(1f);
            }
        }
        if (TanksToSpawn[CurrentRound] > 0)
        {
            for (int i = 0; i < TanksToSpawn[CurrentRound]; i++)
            {
                TankEnemys[i].SetActive(true);
                TankEnemys[i].transform.position = SpawnPoint.position;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
