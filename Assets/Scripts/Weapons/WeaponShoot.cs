using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private Transform FPM;
    private Transform FPOne;
    private Transform FPTwo;
    private WeaponObj currentWeapon;
    private GameObject bullet;

    private float shootInterval = 0f;
    private const float bulletPower = 15f;

    private void Awake()
    {
        //Initialize variables and objects.
        currentWeapon = this.gameObject.GetComponent<WeaponObj>();
        bullet = Resources.Load<GameObject>(currentWeapon.ammoType);
        FPM = this.transform.Find("FPM");
    }
    void Update()
    {
      if (Input.GetButton("Fire1") && Time.time >= shootInterval)
      {
        shootInterval = Time.time + 1f / currentWeapon.FireSpeed;
        Shoot();
      }
    }

    void Shoot()
    {
        GameObject bulletFired = Instantiate(bullet, FPM.position, FPM.rotation);
        Rigidbody2D bulletFiredRB = bulletFired.GetComponent<Rigidbody2D>();
        bulletFiredRB.AddForce(FPM.up * bulletPower, ForceMode2D.Impulse);
    }
}
