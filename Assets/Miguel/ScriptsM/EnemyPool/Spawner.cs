using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ejemplo de otro script usando el Object Pooling
public class Spawner : MonoBehaviour
{
    public EnemyObjectPool enemyPool;

    void Start()
    {
        enemyPool = FindObjectOfType<EnemyObjectPool>(); // Encuentra el Object Pool de los enemigos
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyPool.enemyPool.Count; i++)
        {
            GameObject enemy = enemyPool.GetEnemyFromPool(); // Obtener un enemigo del pool
            enemy.transform.position = transform.position; // Posicionar al enemigo
            enemy.SetActive(true); // Activar al enemigo
        }
        
    }
}

