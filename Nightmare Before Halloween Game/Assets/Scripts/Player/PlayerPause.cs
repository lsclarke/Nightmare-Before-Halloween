using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject Menu;
    public MouseCameraScript script;
    public Weapon script2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Invoke("Pause", 0.2f);

            }else
            {
                Invoke("UnPaused", 0.01f);
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Menu.SetActive(true);
        script.enabled = false; 
        script2.enabled = false;
        isPaused = true;
    }

    public void UnPaused()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
        script.enabled = true; 
        script2.enabled = true;
        isPaused = false;
    }

    public void Quit()
    {
        Menu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene(0);
    }
}
