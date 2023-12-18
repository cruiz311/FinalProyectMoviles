using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player_data", menuName = "ScriptableObjects/Player_data")]
public class Player_data : ScriptableObject
{
    public string Id_firebase;
    public int Nivel;
    public string Nombre;
    public int Puntos_experiencia;
    public int Puntos_maximo_experiencia;
    public int Energia;
    public int Energia_maxima;
    public int Puntos_magia;

    public void Set_Id_firebase(string Id_firebase)
    {
        this.Id_firebase = Id_firebase;
    }
    public void Set_Nivel(int Nivel)
    {
        this.Nivel = Nivel;
    }
    public void Set_Nombre(string Nombre)
    {
        this.Nombre = Nombre;
    }
    public void Set_Puntos_experiencia(int Puntos_experiencia)
    {
        this.Puntos_experiencia = Puntos_experiencia;
    }
    public void Set_Puntos_maximo_experiencia(int Puntos_maximo_experiencia)
    {
        this.Puntos_maximo_experiencia = Puntos_maximo_experiencia;
    }
    public void Set_Energia(int Energia)
    {
        this.Energia = Energia;
    }
    public void Set_Energia_maxima(int Energia_maxima)
    {
        this.Energia_maxima = Energia_maxima;
    }
    public void Set_Puntos_magia(int Puntos_magia)
    {
        this.Puntos_magia = Puntos_magia;
    }



}
