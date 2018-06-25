using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPerfab;

    [SerializeField]
    float spawnTimer = 5f;

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
        Debug.Log("Swanning");
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }


    void StopSpawning()
    {
        CancelInvoke();
    }
}
