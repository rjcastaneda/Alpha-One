using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnimator;
    private Component[] enemyColliders;
    private PlayerData player;

    public float health;
    public string type;
    public int enemyScore;
    public bool isDead;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.gameObject.GetComponent<Animator>();
        enemyColliders = this.gameObject.GetComponents(typeof(Collider2D));
        player = GameObject.Find("Player").GetComponent<PlayerData>();
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
            foreach(Collider2D Colliders in enemyColliders) { Colliders.enabled = false; }
            Destroy(this.gameObject, 1f);
            player.score = player.score + enemyScore;
            isDead = true;
        }
       
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }
}
