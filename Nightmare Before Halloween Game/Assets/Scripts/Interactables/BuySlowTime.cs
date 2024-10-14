using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuySlowTime : MonoBehaviour, IInteractable
{
    public float RequiredPoints;
    public GameObject BuyUI;
    public ScoreManagerScript ScoreManager;
    public TextMeshProUGUI text;
    private float OriginalTime;
    public float FreezeTime = 10;

    public bool isOn = false;

    public AudioSource Speaker;
    public AudioClip[] clips;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BuyUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BuyUI.SetActive(false);
        }
    }

    private void Update()
    {
        text.text = FreezeTime.ToString("f1");

        if (isOn)
        {
            FreezeTime -= Time.deltaTime;
        }
    }

    private void BuyTimeStop()
    {
        OriginalTime = FreezeTime;
        if (ScoreManager.ShowPoints() >= RequiredPoints & BuyUI.active )
        {
            isOn = true;
            Time.timeScale = 0.25f;
            ScoreManager.subScore(RequiredPoints);
            StartCoroutine(ColorText());
            StartCoroutine(FreezeTimer());

            int rand = Random.Range(0, 1);

            if (rand == 0)
            {
                Speaker.PlayOneShot(clips[1]);
            }
            else
            {
                Speaker.PlayOneShot(clips[0]);
            }

        }
    }

    IEnumerator FreezeTimer()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(FreezeTime);
        isOn = false;
        Time.timeScale = 1f;
        text.gameObject.SetActive(false);
        FreezeTime = OriginalTime;

    }

    IEnumerator ColorText()
    {
        text.color = Color.green;
        yield return new WaitForSeconds(0);
        text.color = Color.white;
    }

    void IInteractable.Interact()
    {
        BuyTimeStop();
    }
}

