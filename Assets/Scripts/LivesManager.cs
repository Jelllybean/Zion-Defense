using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public float LivesCount = 150;

    [SerializeField] private TextMeshPro LivesText;

    void Update()
    {
        LivesText.text = "Lives: " + LivesCount;
    }
}
