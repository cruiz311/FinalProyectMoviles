using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class viewPuntuacionesSo : MonoBehaviour
{
    public TMP_Text[] textos;
    public PuntuacionesSO puntuaciones;

    private void Update()
    { 
        textos[0].text = "Cantidad de enemigos asesinados: " + puntuaciones.enemigosMatados;
        textos[1].text = "Cantidad de mapas superados: " + puntuaciones.mapasSuperados;
    }
}
