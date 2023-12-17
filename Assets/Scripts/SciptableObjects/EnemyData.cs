using UnityEngine;

public enum EnemyType
{
    Terrestre,
    aereo,
}
[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("Datos Generales")]
    public int vida;
    public int maxVida;
    public int damage;
    public int velocidad;
    public float distanciaDeAtaque;
    [Header("Prefab")]
    public GameObject enemyPrefab; // Referencia al prefab del enemigo
    [Header("Generalidades de un prefab")]
    public RuntimeAnimatorController anim;
    [SerializeField]
    [Header("Tipo de enemigo")]
    public EnemyType enemyType;

    // Otras propiedades que puedas necesitar para tu enemigo

    public GameObject InstantiateEnemy(Vector3 position, Quaternion rotation)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, position, rotation);
        Animator animator = newEnemy.AddComponent<Animator>();
        animator.runtimeAnimatorController = anim;

        if (enemyType == EnemyType.Terrestre)
        {
            newEnemy.AddComponent<EnemyFollowAtPlayer>();
            EnemyFollowAtPlayer a = newEnemy.GetComponent<EnemyFollowAtPlayer>();
            AsignarDatosTerrestre(a);
        }
        else
        {
            newEnemy.AddComponent<EnemyNotFollowAtPlayer>();
            EnemyNotFollowAtPlayer a = newEnemy.GetComponent<EnemyNotFollowAtPlayer>();
            AsignarDatosAereo(a);
        }
        return newEnemy;
    }

    public void AsignarDatosTerrestre(EnemyFollowAtPlayer enemyData)
    {
        enemyData.vida = vida;
        enemyData.maxVida = maxVida;
        enemyData.damage = damage;
        enemyData.velocidad = velocidad;
        enemyData.distanciaDeAtaque = distanciaDeAtaque;
    }

    public void AsignarDatosAereo(EnemyNotFollowAtPlayer enemyData)
    {
        enemyData.vida = vida;
        enemyData.maxVida = maxVida;
        enemyData.damage = damage;
        enemyData.velocidad = velocidad;
    }

    public void a(EnemyNotFollowAtPlayer asdasd)
    {
        if(asdasd != null)
        {

        }
    }
}
