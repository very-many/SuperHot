using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int maxEnemiesNumber;
    [SerializeField] private Transform player;

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private float timeSinceLastSpawn;
    private float currentEnemiesNumber;

    private void Start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn < spawnInterval)
        {
            timeSinceLastSpawn = 0f;
            if(currentEnemiesNumber < maxEnemiesNumber)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
