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
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public void SpawnEnemy(Vector3 spawnPosition)
    {
       
        GameObject enemy = enemyPool.Find(obj => !obj.activeSelf);
        if (enemy != null)
        {
            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);
        }
        else
        {
            
            enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyPool.Add(enemy);
        }
    }

   
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

