using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReloadScript : MonoBehaviour
{
    [Header("Refernce Settings")]

    [SerializeField] public AmmoManagerScript ammoScript;
    public Weapon weaponScript;

    public int newClip;
    private int newMax;
 


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & ammoScript.getAmmo() < newClip)
        {
            ReloadWeapon();
        }
    }


    private void ReloadWeapon()
    {
        if (ammoScript.getAmmo() < newClip && ammoScript.getAmmoMax() >= newClip)
        {
            newMax = ammoScript.getAmmoMax() - newClip;
            ammoScript.setAmmoMax(newMax);
            ammoScript.setAmmo(newClip);
        }
        else
        {
            if (ammoScript.getAmmoMax() > 0)
            {
                ammoScript.setAmmo(ammoScript.getAmmoMax());
                ammoScript.setAmmoMax(0);
            }
        }
    }
}
