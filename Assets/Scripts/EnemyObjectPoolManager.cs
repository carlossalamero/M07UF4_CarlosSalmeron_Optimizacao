using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPoolManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    public List<GameObject> enemyPool = new List<GameObject>();

    void Start()
    {
        // Instantiate enemy objects and add them to the object pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public void SpawnEnemy(Vector3 spawnPosition)
    {
        // Check for a deactivated enemy object in the pool
        GameObject enemy = enemyPool.Find(obj => !obj.activeSelf);
        if (enemy != null)
        {
            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);
        }
        else
        {
            // Instantiate a new enemy object if no deactivated enemy is available
            enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyPool.Add(enemy);
        }
    }

    // Deactivate all enemy objects in the pool
    public void DeactivateAllEnemies()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (enemy.activeSelf)
            {
                enemy.SetActive(false);
            }
        }
    }
}

