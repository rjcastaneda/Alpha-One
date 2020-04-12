using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GunShoot : MonoBehaviour
{
    private Transform FP;
    private GunObj currentWeapon;
    private GameObject bullet;


    private const float bulletPower = 10f;
    private string preFabDir = "Assets/Prefabs/";

    private void Awake()
    {
        //Initialize variables and objects.
        currentWeapon = this.gameObject.GetComponent<GunObj>();
        preFabDir = preFabDir + currentWeapon.ammoType + ".prefab";
        bullet = (GameObject)AssetDatabase.LoadAssetAtPath(preFabDir, typeof(GameObject));
        FP = this.transform.Find("FP");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) { Shoot(); }
    }

    void Shoot()
    {
        if (currentWeapon.ammoClip == 0) { return; }
        GameObject bulletFired = Instantiate(bullet, FP.position, FP.rotation);
        Rigidbody2D bulletFiredRB = bulletFired.GetComponent<Rigidbody2D>();
        bulletFiredRB.AddForce(FP.right * bulletPower, ForceMode2D.Impulse);
        currentWeapon.ammoClip -= 1;
    }
}
