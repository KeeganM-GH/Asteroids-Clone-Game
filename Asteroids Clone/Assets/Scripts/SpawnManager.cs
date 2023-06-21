using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject bigEnemyPrefab;
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
        enemyCount = FindObjectsOfType<Enemy>().Length;

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
            Vector3 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPos = transform.position + spawnPoint;
            Instantiate(enemyPrefabs, spawnPos, enemyPrefabs.transform.rotation);
        }
    }

    void SpawnBigEnemyWave(int currentRound)
    {

        Vector3 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPos = transform.position + spawnPoint;
        Instantiate(bigEnemyPrefab, spawnPos, bigEnemyPrefab.transform.rotation);            
        
    }

    /*private Vector2 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);

        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);

        return randomPos;
    }*/
}
