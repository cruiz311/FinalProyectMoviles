using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vida;
    public int maxVida;
    public int damage;
    public Enemys target;

    public GameObject cuerpo;

    public List<Enemys> listEnemigos = new List<Enemys>();

    void Update()
    {
        UpdateEnemyList();
        if(target != null)
        {
            Vector3 direction = target.transform.position - cuerpo.transform.position;
            direction.y = 0;
            cuerpo.transform.rotation = Quaternion.Slerp(cuerpo.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
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

    public void lookThis(Transform posicion)
    {
        if(posicion != null)
        {
            Vector3 direction = posicion.position - transform.position;
            direction.y = 0;

            if(direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
            }
        }
    }
}
