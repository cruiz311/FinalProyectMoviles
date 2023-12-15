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
        Vector3 spawnPosition = transform.position; // Cambia esta posici�n si necesitas una ubicaci�n espec�fica
        Quaternion spawnRotation = Quaternion.identity; // O cambia la rotaci�n si es necesario

        GameObject newEnemy = enemyData.InstantiateEnemy(spawnPosition, spawnRotation);
        if (newEnemy != null)
        {
            hasSpawnedEnemy = true;
            // Realiza acciones adicionales con el enemigo instanciado si es necesario
        }
    }
}

