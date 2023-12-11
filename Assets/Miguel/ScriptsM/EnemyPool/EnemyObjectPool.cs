using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public int poolSize = 10; // Tamaño inicial del pool
    public List<GameObject> enemyPool; // Lista para almacenar los enemigos disponibles

    void Start()
    {
        enemyPool = new List<GameObject>();

        // Crear y almacenar enemigos iniciales en el pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);
            enemy.SetActive(false); // Desactivar el enemigo inicialmente
            enemyPool.Add(enemy);
        }
    }

    // Método para obtener un enemigo del pool
    public GameObject GetEnemyFromPool()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true); // Activar el enemigo encontrado
                return enemy;
            }
        }

        // Si no hay enemigos inactivos en el pool, crear uno nuevo y agregarlo al pool
        GameObject newEnemy = Instantiate(enemyPrefab, transform);
        newEnemy.SetActive(true);
        enemyPool.Add(newEnemy);

        return newEnemy;
    }

    // Método para desactivar un enemigo y devolverlo al pool
    public void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false); // Desactivar el enemigo
    }
}
