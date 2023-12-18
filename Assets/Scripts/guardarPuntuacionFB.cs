using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardarPuntuacionFB : MonoBehaviour
{
    public PlayerInfoUi playerInfoUi;
    // Start is called before the first frame update
    void Start()
    {
        playerInfoUi.EnviarDatosFireBase();   
    }
}
