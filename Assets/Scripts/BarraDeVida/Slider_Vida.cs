using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Vida : MonoBehaviour
{
    public int VidaEnemigo;
    public Slider Vida;

    private void Update()
    {
        Vida.value = VidaEnemigo;
    }
}
