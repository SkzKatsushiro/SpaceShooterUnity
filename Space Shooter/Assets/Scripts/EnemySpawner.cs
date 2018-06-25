using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPerfab;

    [SerializeField]
    private float spawnTimer = 5f;

    [SerializeField]
    private float maxSpawnTimes = 5f;

    private float currentSpawnTimes = 0f;

    private void OnEnable()
    {
        EventManager.onStartGame += StartSpawning;
    }

    private void OnDisable()
    {
        StopSpawning();
        EventManager.onStartGame -= StartSpawning;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPerfab, transform.position, Quaternion.identity);
    }

    void StartSpawning()
    {
        if(currentSpawnTimes >= maxSpawnTimes)
        {
            return;
        }
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
        currentSpawnTimes++;
    }


    void StopSpawning()
    {
        CancelInvoke();
    }
}
