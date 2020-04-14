using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private PlayerData _playerData;
    private Transform FPM;
    private Transform FPOne;
    private Transform FPTwo;
    private WeaponObj currentWeapon;
    private GameObject bullet;

    private float shootInterval = 0f;
    private const float bulletPower = 15f;

    private bool wShot;

    private void Awake()
    {
        //Initialize variables, objects, and defaults.
        currentWeapon = this.gameObject.GetComponent<WeaponObj>();
        bullet = Resources.Load<GameObject>(currentWeapon.ammoType);
        _playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        FPM = this.transform.Find("FPM");
        FPOne = this.transform.Find("FP1");
        FPTwo = this.transform.Find("FP2");
    }

    void Update()
    {
      if (Input.GetButton("Fire1") && Time.time >= shootInterval)
      {
        shootInterval = Time.time + 1f / (currentWeapon.FireSpeed * _playerData.asMod);
        Shoot();
      }
      wShot = _playerData.wShot;
    }

    void Shoot()
    {
        //For singular fire.
        if(!wShot)
        {
            GameObject bulletFired = Instantiate(bullet, FPM.position, FPM.rotation);
            Rigidbody2D bulletFiredRB = bulletFired.GetComponent<Rigidbody2D>();
            bulletFiredRB.AddForce(FPM.up * bulletPower, ForceMode2D.Impulse);
        }
        
        //For multiple file.
        if(wShot)
        {
            GameObject bulletFired = Instantiate(bullet, FPM.position, FPM.rotation);
            GameObject bulletFiredTwo = Instantiate(bullet, FPOne.position, FPOne.rotation);
            GameObject bulletFiredThree = Instantiate(bullet, FPTwo.position, FPTwo.rotation);
            Rigidbody2D bulletFiredRB = bulletFired.GetComponent<Rigidbody2D>();
            Rigidbody2D bulletFiredRBTwo = bulletFiredTwo.GetComponent<Rigidbody2D>();
            Rigidbody2D bulletFiredRBThree = bulletFiredThree.GetComponent<Rigidbody2D>();
            bulletFiredRB.AddForce(FPM.up * bulletPower, ForceMode2D.Impulse);
            bulletFiredRBTwo.AddForce(FPM.up * bulletPower, ForceMode2D.Impulse);
            bulletFiredRBThree.AddForce(FPM.up * bulletPower, ForceMode2D.Impulse);
        }
    }
}
