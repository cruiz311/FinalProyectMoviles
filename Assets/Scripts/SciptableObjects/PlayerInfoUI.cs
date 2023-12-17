using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerInfoUi", menuName = "Player Info Ui ", order = 3)]
public class PlayerInfoUi : ScriptableObject
{
    [Header("Datos Generales")]
    public int nivel;
    public int puntosExperiencia;
    public int puntosMaximoExperiencia;
    [Range(0,100)]
    public int energia;
    public int energiaMaxima;
    public int PuntosMagia;

    public void Awake()
    {
        energia = energiaMaxima;
    }

    public void ActualizarNivel()
    {
        if(puntosExperiencia >= puntosMaximoExperiencia)
        {
            nivel++;
            puntosExperiencia = 0;
            puntosMaximoExperiencia = (int)(puntosMaximoExperiencia * 1.5f);
        }
    }
}
