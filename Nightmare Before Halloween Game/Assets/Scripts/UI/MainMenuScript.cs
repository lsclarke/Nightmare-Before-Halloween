using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject ControlCanvas;
    public Animator TransitionBackground;

    private bool Playing;
    private float timer = 0;

    public AudioSource Speaker;
    public AudioClip[] clip;

    private void Update()
    {
        if (Playing)
        {
            
            timer += Time.deltaTime;

            if (timer > 2.5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    public void Play()
    {
        TransitionBackground.SetTrigger("FadeToBlack");
        Playing = true;
        Speaker.PlayOneShot(clip[0]);
    }

    public void Controls()
    {
        ControlCanvas.SetActive(true);
        MainCanvas.SetActive(false);
        Speaker.PlayOneShot(clip[0]);

    }

    public void Back()
    {
        ControlCanvas.SetActive(false);
        MainCanvas.SetActive(true);
        Speaker.PlayOneShot(clip[0]);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
