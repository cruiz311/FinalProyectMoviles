using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta : MonoBehaviour
{
    public List<Enemys> listEnemigos = new List<Enemys>();
    public GameObject metaObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyList();
        if (listEnemigos.Count < 1)
        {
            metaObject.SetActive(true);
        }
        
    }
    void UpdateEnemyList()
    {
        listEnemigos.Clear(); // Limpiamos la lista actual para volver a llenarla

        Enemys[] enemigosEnEscena = FindObjectsOfType<Enemys>(); // Encuentra todos los objetos con el script Enemys

        foreach (Enemys enemigo in enemigosEnEscena)
        {
            if (enemigo.CompareTag("Enemy"))
            {
                listEnemigos.Add(enemigo); // Agrega el enemigo a la lista si tiene el tag "Enemy"
            }
        }
    }

}
