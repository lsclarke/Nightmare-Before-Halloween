using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuyGuns : MonoBehaviour, IInteractable
{
    public float RequiredPoints;
    public GameObject BuyUI;
    public ScoreManagerScript ScoreManager;
    public AmmoManagerScript AmmoManager;
    public TextMeshProUGUI text;

    public Transform HandPosition;
    public GameObject NewWeapon;
    private GameObject PreviousWeapon;

    public int Ammo;
    public int MaxAmmo;

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

    private void BuyGun()
    {
        if (ScoreManager.ShowPoints() >= RequiredPoints & BuyUI.active)
        {
            StartCoroutine(ColorText());
            ScoreManager.subScore(RequiredPoints);
            AmmoManager.setAmmo(Ammo);
            AmmoManager.setAmmoMax(MaxAmmo);

            int rand = Random.Range(0, 1);

            if (rand == 0)
            {
                Speaker.PlayOneShot(clips[1]);
            }
            else
            {
                Speaker.PlayOneShot(clips[0]);
            }


            PreviousWeapon = HandPosition.GetChild(0).gameObject;
            var clone = Instantiate(NewWeapon, HandPosition.position, Quaternion.identity);
            clone.transform.position = PreviousWeapon.transform.position;
            clone.transform.localScale = PreviousWeapon.transform.localScale;
            clone.transform.localRotation = HandPosition.rotation;
            clone.transform.parent = HandPosition;
            

            
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
        BuyGun();
        Destroy(PreviousWeapon);
    }

}