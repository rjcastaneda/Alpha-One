using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerData playerData;
    private bool invincible = false;
    private bool playerDead = false;
    private void Start()
    {
        playerData = this.gameObject.GetComponent<PlayerData>();
    }

    public void Update()
    {
       if(playerData.lives < 0)
        {
            death();
        }
    }

    public void takeDamage()
    {
        if(!invincible)
        {
            invincible = true;
            playerData.lives -= 1;
            yield return WaitForSeconds(3f);
        }
    }

    public void death()
    {
        playerDead = true;
        this.gameObject.SetActive(false);
    }
    
}
