using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript:MonoBehaviour
{
    Stack<GameObject> maderas = new();
    public GameObject maderaGO;
    public int cantidad;
    private void Update()
    {
        for (int i = 0; i < cantidad; i++)
        {
            maderas.Push(maderaGO);
        }
        Debug.Log(maderas.Count);
    }

    public void CrearMaderas()
    {
        

        
    }
}
