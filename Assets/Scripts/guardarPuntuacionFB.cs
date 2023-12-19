using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class guardarPuntuacionFB : MonoBehaviour
{
    public PlayerInfoUi playerInfoUi;

    public PuntuacionesSO puntuaciones;

    public TMP_Text[] textos;
    // Start is called before the first frame update
    void Start()
    {
        textos[0].text = puntuaciones.enemigosMatados.ToString();
        textos[1].text = puntuaciones.mapasSuperados.ToString();
        playerInfoUi.ActualizarNivel();
        playerInfoUi.EnviarDatosFireBase();   
    }
}
