using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data", order = 2)]
public class PlayerData : ScriptableObject
{
    [Header("Datos Generales")]
    public int vida;
    public int maxVida;
    public int damage;
    public float velocidad_Ataque;
}
