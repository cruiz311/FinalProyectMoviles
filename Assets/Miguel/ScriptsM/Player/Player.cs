using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vida;
    public int maxVida;
    public int damage;
    public Enemys target;

    public List<Enemys> listEnemigos = new List<Enemys>();

    void Update()
    {
        UpdateEnemyList();
        transform.LookAt(target.transform);
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

        // Ordenar la lista de enemigos según su distancia al jugador
        listEnemigos.Sort((enemigoA, enemigoB) =>
            Vector3.Distance(transform.position, enemigoA.transform.position)
            .CompareTo(Vector3.Distance(transform.position, enemigoB.transform.position))
        );

        // Asignar el primer enemigo de la lista como objetivo (target)
        if (listEnemigos.Count > 0)
        {
            target = listEnemigos[0];
        }
        else
        {
            target = null; // No hay enemigos en la lista, el objetivo es nulo
        }
    }
}
