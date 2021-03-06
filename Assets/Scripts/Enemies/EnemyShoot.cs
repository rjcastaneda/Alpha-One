﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private Transform FPM;

    private const float bulletPower = 2f;
    private const float delayShot = 5f;

    public List<BulletPatterns> shootPatterns;
    public float timeInterval;
    
    public bool shootAble;

    private void Awake()
    {
        FPM = this.transform.Find("EnemyFP");
    }
    public void Update()
    {
       //chooses random pattern from list and shoots it.
       //There is a grace period after each shot;
       int rIndex = Random.Range(0, shootPatterns.Count);
       if (Time.time >= timeInterval) 
       {
           timeInterval = Time.time + 1f + delayShot;
           if (!shootPatterns[rIndex].burstFire )
           {
              Shoot(shootPatterns[rIndex]);
           }

           if(shootPatterns[rIndex].burstFire)
           {
              StartCoroutine(BurstFire(shootPatterns[rIndex]));
           }
       }
    }

    //If the pattern is a burst fire, it will shoot the same pattern a number of times 
    //Before shooting the next volley.
    private IEnumerator BurstFire(BulletPatterns pattern)
    {
        int x = 0;
        while(x < pattern.burstAmount)
        {
            Shoot(pattern);
            yield return new WaitForSeconds(pattern.burstFireDelay);
            x++;
        }
    }

    //To shoot a pattern, we use trigonometry and a for loop to make bullets shoot
    //at different ways based on the number of bullets in the volley.
    private void Shoot(BulletPatterns pattern)
    {
        GameObject bulletToShoot;
        Rigidbody2D bulletToShootRB;
        Vector2 directionFire;
        float stepAngle = (pattern.angleOne - pattern.angleTwo) / pattern.numShots;
        float dirAngle = pattern.angleOne;
        float fireX;
        float fireY;

        for (int x = 0; x < pattern.numShots; x++)
        {
            //Grab bullet, set it at the FP.
            bulletToShoot = EnemyBulletPool.Instance.GetFromPool();
            bulletToShootRB = bulletToShoot.GetComponent<Rigidbody2D>();
            bulletToShoot.transform.position = FPM.position;

            //Get direction to shoot at.
            fireX = Mathf.Cos((dirAngle * Mathf.PI) / 180f);
            fireY = Mathf.Sin((dirAngle * Mathf.PI) / 180f);
            directionFire = new Vector2(fireX, fireY);
            bulletToShootRB.AddForce((directionFire * bulletPower), ForceMode2D.Impulse);

            dirAngle += stepAngle;
        }
    }
}

