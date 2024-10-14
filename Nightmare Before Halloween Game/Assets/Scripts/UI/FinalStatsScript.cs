using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class FinalStatsScript : MonoBehaviour
{
    [Header("Refernce Settings")]
    public TextMeshProUGUI ZombiesText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI finalRoundText;
    public ScoreManagerScript scoreManagerScript;
    public RoundManagerScript roundManagerScript;

    public Animator TransitionBackground;
    private bool Playing;
    private float timer = 0;

    private void FixedUpdate()
    {
        UpdateScore();

        if (Playing)
        {

            timer += Time.deltaTime;

            if (timer > 2.5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

    public void Quit()
    {
        TransitionBackground.SetTrigger("FadeToBlack");
        Playing = true;
    }

    private void UpdateScore()
    {
        finalRoundText.text = "You Survived " + roundManagerScript.ShowRound() + " Rounds";
        ZombiesText.text = "Zombie Kills: " + scoreManagerScript.ShowKills(); 
        HighScoreText.text =  "Highscore: " + scoreManagerScript.ShowHighScore();
    }
}
