using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    Rigidbody2D thisBulletRB;
    Transform thisBulleT;
    private const float bulletPower = 10f;

    private void Awake()
    {
        thisBulletRB = this.gameObject.GetComponent<Rigidbody2D>();
        thisBulleT = this.gameObject.GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Vector3 contactNormal = collision.contacts[0].normal;
            Vector3 newDirection = Vector3.Reflect(thisBulletRB.velocity, contactNormal).normalized;
            float angle = 90 - Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
            thisBulleT.eulerAngles = new Vector3 (0, 0, angle);
            thisBulletRB.velocity = newDirection;
        }
    }
}
