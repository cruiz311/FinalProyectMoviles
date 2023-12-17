using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "SceneInfo", order = 1)]
public class SceneInfo : ScriptableObject
{
    public GameObject terreno;
    public GameObject enemySpawnerPrefab;

    public void CreateSceneElements()
    {
        // Asegúrate de que haya una referencia válida al terreno y al prefab del spawner
        if (terreno != null && enemySpawnerPrefab != null)
        {
            // Instancia el terreno
            GameObject newTerreno = Instantiate(terreno);

            // Instancia el EnemySpawner y átalo al terreno instanciado
            GameObject spawnerInstance = Instantiate(enemySpawnerPrefab, newTerreno.transform);

            // Configura la posición del spawner dentro del terreno si es necesario
            spawnerInstance.transform.localPosition = Vector3.zero;
        }
    }
}
