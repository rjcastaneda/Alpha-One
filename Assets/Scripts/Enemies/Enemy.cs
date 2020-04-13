using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnimator;
    private EnemyMoveController thisMoveController;
    private Component[] enemyColliders;
    private PlayerData player;
    private EnemyShoot thisEnemyShoot;

    public float health;
    public float movementSpeed;
    public string type;
    public int enemyScore;
    public bool isDead;
    public bool justSpawned;
    public bool moveLeft;
    public bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        thisEnemyShoot = this.gameObject.GetComponent<EnemyShoot>();
        enemyAnimator = this.gameObject.GetComponent<Animator>();
        thisMoveController = this.gameObject.GetComponent<EnemyMoveController>();
        enemyColliders = this.gameObject.GetComponents(typeof(Collider2D));
        player = GameObject.Find("Player").GetComponent<PlayerData>();
        isDead = false;
    }

    private void Awake()
    {
        moveLeft = Random.Range(-1, 2) == 0;
        moveRight = !moveLeft;
        justSpawned = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (health < 0){ Death(); }
        if (!justSpawned) { thisEnemyShoot.enabled = true; }
        if (justSpawned) 
        { 
            thisEnemyShoot.enabled = false;
            thisMoveController.MoveToPlayField();
        }
        else if (moveLeft) { thisMoveController.EnemyMoveL(.005f, movementSpeed); }
        else if (moveRight) { thisMoveController.EnemyMoveR(.005f, movementSpeed); }

    }

    void Death()
    {
        if(!isDead)
        {
            enemyAnimator.SetTrigger("Dead");
            foreach(Collider2D Colliders in enemyColliders) { Colliders.enabled = false; }
            Destroy(this.gameObject, 1f);
            player.score += enemyScore;
            isDead = true;
        }
    }

    public void TakeDamage(float damage){ health -= damage; }
}
