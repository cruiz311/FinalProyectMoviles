using UnityEngine;
using System.Collections.Generic;

public class EnemyObjectPool : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public int poolSize = 10; // Tamaño del pool
    private List<GameObject> enemyPool = new List<GameObject>();

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            enemy.SetActive(false); // Desactivar el enemigo al instanciarlo
            enemyPool.Add(enemy); // Agregar el enemigo al pool
        }
    }

    public GameObject GetEnemyFromPool()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy) // Buscar un enemigo inactivo en el pool
            {
                return enemyPool[i]; // Devolver el enemigo inactivo
            }
        }

        // Si todos los enemigos están activos, aumentar el tamaño del pool
        GameObject newEnemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        newEnemy.SetActive(false);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }
}
