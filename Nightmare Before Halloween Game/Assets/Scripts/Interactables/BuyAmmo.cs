using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyAmmo : MonoBehaviour, IInteractable
{
    public float RequiredPoints;
    public GameObject BuyUI;
    public ScoreManagerScript ScoreManager;
    public AmmoManagerScript AmmoManager;
    public TextMeshProUGUI text;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
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

    private void BuyMoreAmmo()
    {
        if (ScoreManager.ShowPoints() >= RequiredPoints & BuyUI.active)
        {
            StartCoroutine(ColorText());
            ScoreManager.subScore(RequiredPoints);
            AmmoManager.setAmmo(25);
            AmmoManager.setAmmoMax(200);
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
        BuyMoreAmmo();
    }
}
