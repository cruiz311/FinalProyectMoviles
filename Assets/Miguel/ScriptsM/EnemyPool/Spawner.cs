using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ejemplo de otro script usando el Object Pooling
public class Spawner : MonoBehaviour
{
    public EnemyObjectPool enemyPool;
    public float spawnInterval = 2f; // Intervalo de tiempo entre cada spawn

    void Start()
    {
        enemyPool = FindObjectOfType<EnemyObjectPool>(); // Encuentra el Object Pool de los enemigos
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval); // Invoca el método SpawnEnemy repetidamente con el intervalo especificado
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetEnemyFromPool(); // Obtener un enemigo del pool

        if (enemy != null)
        {
            enemy.transform.position = transform.position; // Posicionar al enemigo
            enemy.SetActive(true); // Activar al enemigo
        }
    }
}

