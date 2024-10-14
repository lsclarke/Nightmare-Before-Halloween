using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource Speaker;
    public AudioClip[] clips;

    public GameObject Bullet;
    public Transform BulletSpawn;
    public int CurrentAmmoCount;
    public int MaxAmmoCount;

    public float fireRate = 15;
    public float NextTimeToFire = 0;

    public bool isShooting;

    public AmmoManagerScript ammo;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P) || Input.GetMouseButton(0))
        {
            if(Time.time >= NextTimeToFire)
            {
                SpawnBullet();
            }
        }
    }

    public GameObject SpawnBullet()
    {
        if (ammo.getAmmo() > 0)
        {
            NextTimeToFire = Time.time + 1f / fireRate;
            var clone = Instantiate(Bullet, BulletSpawn.position, Quaternion.identity);
            clone.GetComponent<Projectile>().Init(transform.forward);

            int rand = Random.Range(0, 1);

            if (rand == 0)
            {
                Speaker.PlayOneShot(clips[1]);
            }
            else
            {
                Speaker.PlayOneShot(clips[0]);
            }

            ammo.subAmmo(1);
        }

        return Bullet;
    }

}
