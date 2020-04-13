using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    Enemy thisEnemy;
    Transform enemyT;
    Transform waypointRuler;

    public Vector3 ogPosition;

    // Start is called before the first frame update
    void Start()
    {
        thisEnemy = this.gameObject.GetComponent<Enemy>();
        enemyT = this.gameObject.GetComponent<Transform>();
        waypointRuler = GameObject.Find("EnemyWaypoint").GetComponent<Transform>();
    }

    public void MoveToPlayField()
    {
        Vector3 target = new Vector3(enemyT.position.x, waypointRuler.position.y,enemyT.position.z);
        enemyT.position = Vector3.MoveTowards(enemyT.position, target, Time.deltaTime * 1f);
        if (enemyT.position == target) 
        { 
            thisEnemy.justSpawned = false;
            ogPosition = target;
        }
    }

    public void EnemyMoveL(float amt, float movementSpd)
    {
        Vector3 crntPosition = ogPosition;
        ogPosition.x += amt * Mathf.Sin(Time.time * movementSpd);
        enemyT.position = crntPosition;
    }

    public void EnemyMoveR(float amt, float movementSpd)
    {
        Vector3 crntPosition = ogPosition;
        ogPosition.x += amt * -Mathf.Sin(Time.time * movementSpd);
        enemyT.position = crntPosition;
    }
}
