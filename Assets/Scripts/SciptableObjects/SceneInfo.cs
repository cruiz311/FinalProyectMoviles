using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "SceneInfo", order = 1)]
public class SceneInfo : ScriptableObject
{
    public GameObject terreno;
    public GameObject enemySpawnerPrefab;

    private GameObject instantiatedTerreno;
    private GameObject instantiatedSpawner;
    public void CreateSceneElements()
    {
        if (terreno != null && enemySpawnerPrefab != null)
        {
            instantiatedTerreno = Instantiate(terreno);
            instantiatedSpawner = Instantiate(enemySpawnerPrefab, instantiatedTerreno.transform);
            instantiatedSpawner.transform.localPosition = Vector3.zero;
        }
    }

    public void ClearSceneElements()
    {
        if (instantiatedSpawner != null)
        {
            Destroy(instantiatedSpawner);
        }

        if (instantiatedTerreno != null)
        {
            Destroy(instantiatedTerreno);
        }
    }
}
