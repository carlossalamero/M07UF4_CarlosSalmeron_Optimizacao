using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject enemyPrefab;
    public int enemyPoolSize = 10;
    public Transform target;

    private List<GameObject> enemyPool;

    void Start()
    {
        enemyPool = new List<GameObject>();

        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    void Update()
    {
        
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        
        gameObject.SetActive(false);
    }
}

