using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Weapon;

public class AmmoManagerScript : MonoBehaviour
{
    [Header("Refernce Settings")]
    public TextMeshProUGUI ammoText;
    public Weapon weaponScript;
    [Space(5)]

    [Header("Score Stats Variables")]
    public static int maxAmmoCount;
    public static int currentAmmoCount;

    private void Awake()
    {
        WeaponAmmo();
    }

    public int subAmmo(int num)
    {
        currentAmmoCount -= num;
        return currentAmmoCount;
    }

    public void setAmmo(int num) => currentAmmoCount = num;
    public void setAmmoMax(int num) => maxAmmoCount = num;
    public int getAmmo() => currentAmmoCount;
    public int getAmmoMax() => maxAmmoCount;

    public int AmmoCount()
    {
        return currentAmmoCount;
    }

    public void WeaponAmmo()
    {
        setAmmo(25);
        setAmmoMax(200);
    }

    private void UpdateAmmo()
    {
        ammoText.text = "Ammo: "+ getAmmo().ToString()+ "/" + getAmmoMax().ToString();       
    }

    private void FixedUpdate()
    {
       
        UpdateAmmo();
    }
}
