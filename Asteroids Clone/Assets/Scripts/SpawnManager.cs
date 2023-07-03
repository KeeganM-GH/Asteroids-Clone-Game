using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject bigEnemyPrefab;
    public GameObject miniEnemyPrefab;
    public float spawnDistance = 10f;
    public int enemyCount;
    public int waveNumber = 1;
    public int bigEnemyRound;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length + FindObjectsOfType<EnemyBigShip>().Length + FindObjectsOfType<EnemyShooters>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            
            if (waveNumber % bigEnemyRound == 0)
            {
                SpawnBigEnemyWave(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {   
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            Vector3 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPos = transform.position + spawnPoint;
            Instantiate(enemyPrefabs[randomEnemy], spawnPos, enemyPrefabs[randomEnemy].transform.rotation);
        }
    }

    void SpawnBigEnemyWave(int currentRound)
    {
        int miniEnemysToSpawn;

        if(bigEnemyRound != 0)
        {
            miniEnemysToSpawn = currentRound / bigEnemyRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }

        Vector3 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPos = transform.position + spawnPoint;
        var bigEnemy = Instantiate(bigEnemyPrefab, spawnPos, bigEnemyPrefab.transform.rotation); 
        bigEnemy.GetComponent<EnemyBigShip>().miniEnemySpawnCount = miniEnemysToSpawn;           
        
    }

    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPos = transform.position + spawnPoint;
            Instantiate(miniEnemyPrefab, spawnPos, miniEnemyPrefab.transform.rotation);
        }
    }

}
