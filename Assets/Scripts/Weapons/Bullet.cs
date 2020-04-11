﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Animator bulletAnimator;
    private Collider2D bulletCollider;

    public string bulletType;
    public float  damage;

    //timeBeforeDestroy = 1.5 seconds
    private float timeBeforeDestroy = 2f;

    public void Awake()
    {
       bulletAnimator = this.gameObject.GetComponent<Animator>();
       bulletCollider = this.gameObject.GetComponent<Collider2D>();
       Destroy(this.gameObject, timeBeforeDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            bulletAnimator.SetTrigger("Hit");
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            bulletCollider.enabled = false;
            Destroy(this.gameObject,.05f);
        }
    }
}
