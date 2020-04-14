using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public GameObject enemy;
        public bool isBoss;
        public int numEnemies;
        public float spawnRate;
    }

    public bool isWaiting;
    public bool isSpawning;
    public bool allWavesCleared;
    public int nextWave;
    public Wave[] waves;
    public Transform[] spawnPoints;

    public float checkInterval;
    

    private void Awake()
    {
        //Set defaults.
        nextWave = 0;
        checkInterval = 2f;
        isWaiting = false;
        isSpawning = true;
    }

    private void Update()
    {
        if (isWaiting)
        {
            if (!EnemyAlive())
            {
                isSpawning = true;
                isWaiting = false;
            }
            
            else
            {
                return;
            }
        }

        if(isSpawning)
        {
            if(allWavesCleared){ return; }
            StartCoroutine(SpawnWave(waves[nextWave]));
            isSpawning = false;
        }
    }

    public bool EnemyAlive()
    {
        //We check if enemies are alive at an interval to reduce stress on the engine.
        checkInterval = checkInterval - Time.deltaTime;
        if( checkInterval <= 0f)
        {
            checkInterval = 2f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                nextWave++;
                if (nextWave == waves.Length){ allWavesCleared = true; }
                Debug.Log("No Enemies");
                return false;
            }
        }

        return true;
    }

     IEnumerator SpawnWave(Wave toSpawn)
    {
        //For loop to spawn enemies a number of times, given the size of the wave.
        for(int x = 0; x < toSpawn.numEnemies; x++)
        {
            SpawnEnemy(toSpawn.enemy,toSpawn.isBoss);
            yield return new WaitForSeconds(1f/toSpawn.spawnRate);
        }

        isWaiting = true;

        yield break;
    }

    void SpawnEnemy(GameObject enemy, bool isBoss)
    {
        //If the enemy wave is not a boss wave, we spawn enemies randomly from the list of spawnpoints.
        if(!isBoss)
        {
            int rndIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[rndIndex].transform.position, spawnPoints[rndIndex].transform.rotation);
        }

        //If the enemy is the boss, we spawn them in the spawnpoint close to the middle.
        if(isBoss)
        {
            int midSpawn = spawnPoints.Length / 2;
            Instantiate(enemy, spawnPoints[midSpawn].transform.position, spawnPoints[midSpawn].transform.rotation);
        }
       
    }
}
