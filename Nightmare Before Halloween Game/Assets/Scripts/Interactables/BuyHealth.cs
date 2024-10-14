using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyHealth : MonoBehaviour, IInteractable
{
    public float RequiredPoints;
    public GameObject BuyUI;
    public ScoreManagerScript ScoreManager;
    public PlayerHealth PlayerHealth;
    public TextMeshProUGUI text;

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

    private void BuyHealthBar()
    {
        if (ScoreManager.ShowPoints() >= RequiredPoints & BuyUI.active & PlayerHealth.myHealth < 3)
        {
            StartCoroutine(ColorText());
            PlayerHealth.myHealth += 1;
            ScoreManager.subScore(RequiredPoints);
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



    IEnumerator ColorText()
    {
        text.color = Color.green;
        yield return new WaitForSeconds(2);
        text.color = Color.white;
    }

    void IInteractable.Interact()
    {
        BuyHealthBar();
    }
}
