using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    public int vida;
    public int maxVida;
    public int damage;
    public int velocidad;
    public GameObject enemyPrefab; // Referencia al prefab del enemigo

    // Otras propiedades que puedas necesitar para tu enemigo

    public GameObject InstantiateEnemy(Vector3 position, Quaternion rotation)
    {
        return Instantiate(enemyPrefab, position, rotation);
    }
}
