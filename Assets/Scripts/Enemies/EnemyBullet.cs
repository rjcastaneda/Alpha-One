using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Animator bulletAnimator;
    private Collider2D bulletCollider;
    private Transform bulletTransform;

    public float damage;

    //timeBeforeDestroy = 2 seconds
    private float timeBeforeDestroy = 2f;

    public void Awake()
    {
        bulletAnimator = this.gameObject.GetComponent<Animator>();
        bulletCollider = this.gameObject.GetComponent<Collider2D>();
        bulletTransform = this.gameObject.GetComponent<Transform>();
        SetInactive(timeBeforeDestroy);
    }

    public void setDirectionFire(Vector2 direction)
    {

    }

    private IEnumerator SetInactive(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bulletAnimator.SetTrigger("Hit");
            collision.gameObject.GetComponent<Player>().takeDamage();
            SetInactive(2f);
        }

        if (collision.gameObject.CompareTag("InvisibleWall")) 
        {
            SetInactive(.15f);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
    }
}
