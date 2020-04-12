using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string bulletType;
    public float  damage;

    //timeBeforeDestroy = 1.5 seconds
    private float timeBeforeDestroy = 1.5f;

    public void Awake()
    {
       Destroy(this.gameObject, timeBeforeDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage); 
            Destroy(this.gameObject); 
        }
    }
}
