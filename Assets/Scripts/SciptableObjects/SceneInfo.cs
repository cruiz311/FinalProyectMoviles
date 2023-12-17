using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "SceneInfo", order = 1)]
public class SceneInfo : ScriptableObject
{
    public GameObject terreno;
    public GameObject enemySpawnerPrefab;

    public void CreateSceneElements()
    {
        // Aseg�rate de que haya una referencia v�lida al terreno y al prefab del spawner
        if (terreno != null && enemySpawnerPrefab != null)
        {
            // Instancia el terreno
            GameObject newTerreno = Instantiate(terreno);

            // Instancia el EnemySpawner y �talo al terreno instanciado
            GameObject spawnerInstance = Instantiate(enemySpawnerPrefab, newTerreno.transform);

            // Configura la posici�n del spawner dentro del terreno si es necesario
            spawnerInstance.transform.localPosition = Vector3.zero;
        }
    }
}
