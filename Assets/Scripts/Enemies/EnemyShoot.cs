using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyShoot : MonoBehaviour
{
    private Transform player;
    private Transform FPM;
    private Enemy thisEnemy;
    private EnemyBulletPool bulletPool;

    private const float bulletPower = 5f;
    private string enemyType;
    

    public List<BulletPatterns> shootPatterns;
    public const float FLIP = -1f;
    public float timeInterval = 0f;

    private void Awake()
    {
        //Initialize variables and objects.
        player = GameObject.Find("Player").GetComponent<Transform>();
        thisEnemy = this.gameObject.GetComponent<Enemy>();
        FPM = this.transform.Find("EnemyFP");
        bulletPool = GameObject.Find("EnemyBulletPool").GetComponent<EnemyBulletPool>();
    }
    public void Update()
    {
        //chooses random pattern from list and shoots it.
        //There is a grace period after each shot;
        ShootByInterval();
    }

    void ShootByInterval(BulletPatterns pattern)
    {
        if (Time.time >= timeInterval)
        {
            Shoot();
            timeInterval = Time.time + 1f + pattern.interval;
        }
    }

    void Shoot(BulletPatterns pattern)
    {
        GameObject bulletToShoot;
        Rigidbody2D bulletToShootRB;
        Vector2 direction;
        float stepAngle = pattern.angleOne - pattern.angleTwo;
        float dirAngle = pattern.angleOne;
        

        if(!pattern.aimPlayer && pattern.rotation)
        {
            for (int x = 0; x < pattern.numShots; x++)
            {
                direction = new Vector2()
                bulletToShoot = bulletPool.getFromPool();
                bulletToShootRB = bulletFired.GetComponent<Rigidbody2D>();
                bulletToShootRB.AddForce(, ForceMode2D.Impulse);
            }

        }

        if(!pattern.aimPlayer && !pattern.rotation)
        {

        }

        if(pattern.aimPlayer)
        {

        }
    }
}

