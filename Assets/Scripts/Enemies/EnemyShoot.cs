using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyShoot : MonoBehaviour
{
    private Transform FPM;
    private GameObject bullet;
    private Enemy thisEnemy;

    private float shootInterval = 0f;
    private const float bulletPower = 5f;
    private string preFabDir;
    private string enemyType;

    public float fireSpeed;
    public const float FLIP = -1f;

    private void Awake()
    {
        //Initialize variables and objects.
        thisEnemy = this.gameObject.GetComponent<Enemy>();
        enemyType = thisEnemy.type;
        preFabDir = enemyType + ".prefab";
        bullet = Resources.Load<GameObject>(preFabDir);
        FPM = this.transform.Find("EnemyFP");
    }

    void Shoot()
    {
        GameObject bulletFired = Instantiate(bullet, FPM.position, FPM.rotation);
        Rigidbody2D bulletFiredRB = bulletFired.GetComponent<Rigidbody2D>();
        bulletFiredRB.AddForce(FPM.up * FLIP * bulletPower, ForceMode2D.Impulse);
    }

}

