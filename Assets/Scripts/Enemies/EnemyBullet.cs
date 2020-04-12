using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private IEnumerator DelayTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    private void SetInactive(float delay)
    {
       StartCoroutine(DelayTimer(delay));
       this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage();
            SetInactive(0f);
        }

        if (collision.gameObject.CompareTag("InvisibleWall")) 
        {
            SetInactive(0f);
        }
    }
}
