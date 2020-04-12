using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerData playerData;
    public bool invincible;
    public bool playerDead;
    private void Start()
    {
        playerData = this.gameObject.GetComponent<PlayerData>();
    }

    public void Update()
    {
       if(playerData.lives < 0)
        {
            Death();
        }
    }
    public IEnumerator DamageTimer(float delay)
    {
        invincible = true;
        yield return new WaitForSeconds(delay);
        invincible = false;
    }
    public void TakeDamage()
    {
        if(!invincible)
        {
            playerData.lives -= 1;
            StartCoroutine(DamageTimer(5f));
        }
    }

    public void Death()
    {
        playerDead = true;
        this.gameObject.SetActive(false);
    }
    
}
