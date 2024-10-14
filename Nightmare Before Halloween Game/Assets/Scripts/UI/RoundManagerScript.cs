using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundManagerScript : MonoBehaviour
{
    [Header("Refernce Settings")]
    public TextMeshProUGUI roundText;
    [Space(5)]

    [Header("Round Stats Variables")]
    public static float RoundCount;


    private void Awake()
    {
        RoundCount = 1;
    }
    public float AddRound(float num)
    {
        RoundCount += num;
        return RoundCount;
    }

    public float ShowRound()
    {
        return RoundCount;
    }

    private void FixedUpdate()
    {
        UpdateRound();
    }

    private void UpdateRound()
    {
        roundText.text = "Round: " + RoundCount.ToString();
    }
}

