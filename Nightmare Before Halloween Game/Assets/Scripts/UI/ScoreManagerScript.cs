using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    [Header("Refernce Settings")]
    public TextMeshProUGUI scoreText;
    [Space(5)]

    [Header("Score Stats Variables")]
    public static float ScorePoints;
    public static float killCount;
    public static float highScore;

    private void Awake()
    {
        killCount = 0;
        highScore = 0;
        ScorePoints = 0;
    }
    public float AddScore(float num)
    {
        ScorePoints += num;
        PlayerPrefs.SetFloat("HighScore", ScorePoints);
        return ScorePoints;
    }

    public float AddKill(float num)
    {
        killCount += num;
        Debug.Log(killCount);
        return killCount;
    }
    public float calHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", ScorePoints);
        if(ScorePoints > highScore)
        {
            highScore = ScorePoints;
        }
        return highScore;
    }

    public float subScore(float num)
    {
        ScorePoints -= num;
        return ScorePoints;
    }
    public float ShowPoints()
    {
        return ScorePoints;
    }

    public float ShowHighScore()
    {
        return highScore;
    }
    public float ShowKills()
    {
        return killCount;
    }

    private void FixedUpdate()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + ScorePoints.ToString();
        calHighScore();
    }
}
