using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    public float deactivateTime = 3f; // Tiempo en segundos antes de desactivar al enemigo automáticamente
    public List<GameObject> enemyPool;

    void Start()
    {
        enemyPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetEnemyFromPool()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                StartCoroutine(DeactivateAfterTime(enemy));
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(enemyPrefab, transform);
        newEnemy.SetActive(true);
        enemyPool.Add(newEnemy);

        StartCoroutine(DeactivateAfterTime(newEnemy));
        return newEnemy;
    }

    public void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
    }

    private IEnumerator DeactivateAfterTime(GameObject enemy)
    {
        yield return new WaitForSeconds(deactivateTime);
        ReturnEnemyToPool(enemy);
    }
}
