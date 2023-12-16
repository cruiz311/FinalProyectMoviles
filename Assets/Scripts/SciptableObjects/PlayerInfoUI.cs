using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerInfoUi", menuName = "Player Info Ui ", order = 3)]
public class PlayerInfoUi : ScriptableObject
{
    [Header("Datos Generales")]
    public int nivel;
    public int puntosExperiencia;
    public int puntosMaximoExperiencia;
    public int energia;
    public int energiaMaxima;
    public int PuntosMagia;
}
