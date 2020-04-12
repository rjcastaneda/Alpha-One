using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    private Queue<GameObject> enemyBullets = new Queue<GameObject>();
    private GameObject enemyBullet;
    public static EnemyBulletPool Instance { get; private set; }

    public int poolSize;
    
    private void Awake()
    {
        Instance = this;
        enemyBullet = (GameObject)Resources.Load<GameObject>("enemyBullet");
    }

    private void Start()
    {
        for(int x = 0; x < poolSize; x++)
        {
            GameObject newBullet = Instantiate(enemyBullet);
            newBullet.SetActive(false);
            enemyBullets.Enqueue(newBullet);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject bulletGet = enemyBullets.Dequeue();
        bulletGet.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        bulletGet.SetActive(true);
        enemyBullets.Enqueue(bulletGet);
        return bulletGet;
    }
}
