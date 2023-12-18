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
        Database_firebase.instance.Get_Nivel(ObtenerNivel);
        Database_firebase.instance.Get_Puntos_experiencia(ObtenerpuntosExperiencia);
        Database_firebase.instance.Get_Puntos_maximo_experiencia(ObtenerpuntosMaximoExperiencia);
        Database_firebase.instance.Get_Energia(Obtenerenergia);
        Database_firebase.instance.Get_Energia_maxima(ObtenerarenergiaMaxima);
        Database_firebase.instance.Get_Puntos_magia(ObtenerPuntosDeMagia);
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
    public void ObtenerNivel(int _nivel)
    {
        nivel = _nivel;
    }
    public void ObtenerpuntosExperiencia(int _puntosExperiencia)
    {
        puntosExperiencia = _puntosExperiencia;
    }
    public void ObtenerpuntosMaximoExperiencia(int _puntosMaximoExperiencia)
    {
        puntosMaximoExperiencia = _puntosMaximoExperiencia;
    }
    public void Obtenerenergia(int _energia)
    {
        energia = _energia;
    }
    public void ObtenerarenergiaMaxima(int _energiaMaxima)
    {
        energiaMaxima = _energiaMaxima;
    }
    public void ObtenerPuntosDeMagia(int _puntoMagia)
    {
        PuntosMagia = _puntoMagia;
    }


    public void EnviarDatosFireBase()
    {
        Database_firebase.instance.Set_Nivel(nivel);
        Database_firebase.instance.Set_Energia(energia);
        Database_firebase.instance.Set_Energia_maxima(energiaMaxima);
        Database_firebase.instance.Set_Puntos_experiencia(puntosExperiencia);
        Database_firebase.instance.Set_Puntos_maximo_experiencia(puntosMaximoExperiencia);
        Database_firebase.instance.Set_Puntos_magia(PuntosMagia);
    }
}
