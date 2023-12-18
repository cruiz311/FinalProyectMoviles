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
        for (int i = 0; i < 10; i++)
        {
            CrearEscenario();
        }
        AsignarPrimeraEscena().CreateSceneElements();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EliminarEscenario();
        }
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

            Debug.Log(listaScenas.Count);
            if (listaScenas.Count < 10) // Verificar si la lista tiene menos de 10 escenas
            {
                CrearEscenario(); // Agregar una nueva escena si la lista tiene menos de 10 elementos
            }

            // Actualizar la escena actual si es necesario
            if (listaScenas.Count > 0)
            {
                sceneActual = listaScenas[0];
            }
            else
            {
                sceneActual = null; // O asignar null si no hay m�s escenas en la lista
            }
        }
    }


}
