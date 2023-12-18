using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public SceneInfo[] sceneInfo;
    public List<SceneInfo> listaScenas;
    public SceneInfo sceneActual;


    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            CrearEscenario();
        }
        AsignarPrimeraEscena().CreateSceneElements();
    }

    public void Update()
    {
        
    }

    public void CrearEscenario()
    {
        
        SceneInfo scene = sceneInfo[Random.Range(0, sceneInfo.Length)];
        listaScenas.Add(scene);
    }

    public SceneInfo AsignarPrimeraEscena()
    {
        if (listaScenas.Count > 0)
        {
            sceneActual = listaScenas[0];
        }
        return sceneActual;
    }

    public void EliminarEscenario()
    {
        if (listaScenas.Count > 0)
        {
            AsignarPrimeraEscena().ClearSceneElements();
            listaScenas.RemoveAt(0);
            // También podrías volver a asignar la escena actual si es necesario
            if (listaScenas.Count > 0)
            {
                sceneActual = listaScenas[0];
            }
            else
            {
                sceneActual = null; // O asignar null si no hay más escenas en la lista
            }
        }
    }

}
