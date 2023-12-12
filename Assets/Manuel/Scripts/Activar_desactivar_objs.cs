using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar_desactivar_objs : MonoBehaviour
{

    public List<GameObject> gameObjects_a_desactivar;
    public List<GameObject> gameObjects_a_activar;

    public void Activar()
    {
        foreach (GameObject obj in gameObjects_a_activar)
        {
            obj.SetActive(true);
        }
    }
    public void Desactivar()
    {
        foreach (GameObject obj in gameObjects_a_desactivar)
        {
            obj.SetActive(false);
        }
    }
}
