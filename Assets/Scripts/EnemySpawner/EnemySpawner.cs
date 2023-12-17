using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData[] enemyDatas; // Array de datos de enemigos disponibles
    public int numberOfEnemiesToSpawn = 5; // Cantidad de enemigos a spawnear
    public Transform spawnPoint; // Punto de spawn

    private void Start()
    {
        SpawnEnemiesOnStart();
    }

    void SpawnEnemiesOnStart()
    {
        // Spawnear la cantidad espec�fica de enemigos al inicio del juego
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // Elegir un enemigo aleatorio de los datos disponibles
            EnemyData enemyToSpawn = enemyDatas[Random.Range(0, enemyDatas.Length)];

            // Verificar si el punto de spawn est� asignado y si el enemigo a spawnear est� definido
            if (spawnPoint != null && enemyToSpawn != null)
            {
                // Definir posiciones aleatorias dentro del rango especificado
                float randomX = Random.Range(-5.5f, 5.5f);
                float randomZ = Random.Range(-30f, -13.5f);

                // Crear la posici�n de spawn
                Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, randomZ);

                // Instanciar un enemigo en el punto de spawn con la nueva posici�n
                GameObject newEnemy = enemyToSpawn.InstantiateEnemy(spawnPosition, spawnPoint.rotation);

                // Opcional: Hacer m�s con el nuevo enemigo generado
                // Por ejemplo: newEnemy.GetComponent<EnemyMovement>().SetDestination(someDestination);
            }
        }
    }
}
