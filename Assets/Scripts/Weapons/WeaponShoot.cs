using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeaponShoot : MonoBehaviour
{
    private Transform FPM;
    private Transform FPOne;
    private Transform FPTwo;
    private WeaponObj currentWeapon;
    private GameObject bullet;

    private float shootInterval = 0f;
    private const float bulletPower = 10f;
    private string preFabDir = "Assets/Prefabs/";

    private void Awake()
    {
        //Initialize variables and objects.
        currentWeapon = this.gameObject.GetComponent<WeaponObj>();
        preFabDir = preFabDir + currentWeapon.ammoType + ".prefab";
        bullet = (GameObject)AssetDatabase.LoadAssetAtPath(preFabDir, typeof(GameObject));
        FPM = this.transform.Find("FPM");
    }
    void Update()
    {
      if (Input.GetMouseButton(0) && Time.time >= shootInterval)
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
