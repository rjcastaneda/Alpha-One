﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerData playerData;
    private Animator playerAnimator;
    public bool invincible;
    public bool playerDead;
    private void Start()
    {
        playerData = this.gameObject.GetComponent<PlayerData>();
        playerAnimator = this.gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
       if(playerData.lives <= 0 && !playerDead){ StartCoroutine(Death()); }
    }
    public IEnumerator DamageTimer(float delay)
    {
        invincible = true;
        playerAnimator.SetBool("Invincible", true);
        yield return new WaitForSeconds(delay);
        playerAnimator.SetBool("Invincible", false);
        invincible = false;
    }
    public void TakeDamage()
    {
        if(!invincible && playerData.lives > 0)
        {
            playerData.lives -= 1;
            StartCoroutine(DamageTimer(5f));
        }
    }

    IEnumerator Death()
    {
        playerDead = true;
        playerAnimator.SetTrigger("Dead");
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
    }
    
}
