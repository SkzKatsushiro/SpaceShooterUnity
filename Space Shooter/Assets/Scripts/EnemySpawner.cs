using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPerfab;

    [SerializeField]
    float spawnTimer = 5f;

    private void Start()
    {
        StartSpawning();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPerfab, transform.position, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }


    void StopSpawning()
    {
        CancelInvoke();
    }
}
