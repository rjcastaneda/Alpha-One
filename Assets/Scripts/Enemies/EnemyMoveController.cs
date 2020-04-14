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

    //On spawn, we want to make the enemy move to the game field
    //This is done by moving towards the location of a waypoint 
    //In the scene.
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

    //Enemy will oscillate to the left.
    public void EnemyMoveL(float amt, float movementSpd)
    {
        Vector3 crntPosition = ogPosition;
        ogPosition.x += amt * Mathf.Sin(Time.time * Time.timeScale * movementSpd);
        enemyT.position = crntPosition;
    }

    //Enemy will oscillate ot the right.
    public void EnemyMoveR(float amt, float movementSpd)
    {
        Vector3 crntPosition = ogPosition;
        ogPosition.x += amt * -Mathf.Sin(Time.time * Time.timeScale * movementSpd);
        enemyT.position = crntPosition;
    }
}
