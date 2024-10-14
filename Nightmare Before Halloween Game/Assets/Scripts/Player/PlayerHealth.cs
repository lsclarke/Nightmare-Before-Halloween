using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int myHealth;
    public TextMeshProUGUI HealthText;
    public GameObject[] HealthBars;

    public GameObject EndScreen;
    public GameObject PlayerUI;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        HealthControl();
    }

    public void HealthControl()
    {
        HealthText.text = "Health: " + myHealth;
        if (myHealth == 3)
        {
            HealthBars[0].SetActive(true);
            HealthBars[1].SetActive(true);
            HealthBars[2].SetActive(true);
        }

        if (myHealth == 2)
        {
            HealthBars[0].SetActive(true);
            HealthBars[1].SetActive(true);
            HealthBars[2].SetActive(false);
        }

        if (myHealth == 1)
        {
            HealthBars[0].SetActive(true);
            HealthBars[1].SetActive(false);
            HealthBars[2].SetActive(false);
        }

        if (myHealth <= 0)
        {
            HealthBars[0].SetActive(false);
            HealthBars[1].SetActive(false);
            HealthBars[2].SetActive(false);

            Destroy(gameObject);

            EndScreen.SetActive(true);
            PlayerUI.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            myHealth -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            myHealth -= 1;
        }
    }
}
