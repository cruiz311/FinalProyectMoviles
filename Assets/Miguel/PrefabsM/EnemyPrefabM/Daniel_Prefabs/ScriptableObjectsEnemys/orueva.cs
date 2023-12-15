using UnityEngine;

public class orueva:MonoBehaviour
{
    public EnemyData enemyData;

    private bool hasSpawnedEnemy = false;

    void Start()
    {
        if (!hasSpawnedEnemy && enemyData != null)
        {
            InstantiateEnemyOnce();
        }
    }

    void InstantiateEnemyOnce()
    {
        Vector3 spawnPosition = transform.position; // Cambia esta posición si necesitas una ubicación específica
        Quaternion spawnRotation = Quaternion.identity; // O cambia la rotación si es necesario

        GameObject newEnemy = enemyData.InstantiateEnemy(spawnPosition, spawnRotation);
        if (newEnemy != null)
        {
            hasSpawnedEnemy = true;
            // Realiza acciones adicionales con el enemigo instanciado si es necesario
        }
    }
}

