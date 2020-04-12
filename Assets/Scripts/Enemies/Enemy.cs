using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public int scoreOnDestroy;
    private Animator enemyAnimator;
    public bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.gameObject.GetComponent<Animator>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0){ Death(); }
    }

    void Death()
    {
        if(!isDead)
        {
            enemyAnimator.SetTrigger("Dead");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject, 1f);
            isDead = true;
        }
       
    }

    void Shoot()
    {

    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }
}
