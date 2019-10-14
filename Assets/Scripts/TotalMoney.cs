using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalMoney : MonoBehaviour
{
    public int totalMoneyCounter = 500;
    [SerializeField] private TextMeshPro TextCounter;

    void Start()

    {
        
    }

    void Update()
    {
        TextCounter.text = "Money: " + totalMoneyCounter;
    }
}
