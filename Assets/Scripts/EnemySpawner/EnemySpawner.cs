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
        // Spawnear la cantidad específica de enemigos al inicio del juego
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // Elegir un enemigo aleatorio de los datos disponibles
            EnemyData enemyToSpawn = enemyDatas[Random.Range(0, enemyDatas.Length)];

            // Verificar si el punto de spawn está asignado y si el enemigo a spawnear está definido
            if (spawnPoint != null && enemyToSpawn != null)
            {
                // Instanciar un enemigo en el punto de spawn
                GameObject newEnemy = enemyToSpawn.InstantiateEnemy(spawnPoint.position, spawnPoint.rotation);

                // Opcional: Hacer más con el nuevo enemigo generado
                // Por ejemplo: newEnemy.GetComponent<EnemyMovement>().SetDestination(someDestination);
            }
        }
    }
}
