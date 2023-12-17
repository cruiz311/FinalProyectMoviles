using System.Collections;
using UnityEngine;

public class EnemyFollowAtPlayer : Enemys
{
    public float distanciaDeAtaque = 5.0f; // La distancia a la que el enemigo atacará
    void Update()
    {
        if (jugadorPos != null)
        {
            // Calcula la distancia entre el enemigo y el jugador
            float distancia = Vector3.Distance(transform.position, jugadorPos.position);

            if (distancia <= distanciaDeAtaque)
            {
                Debug.Log("¡Ataque!");
                StartCoroutine(AttackMele());
            }
            else
            {
                Vector3 direction = jugadorPos.transform.position - transform.position;
                direction.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);

                transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            }

            
        }
    }

    IEnumerator AttackMele()
    {
        // Aquí puedes poner la lógica de tu ataque, por ejemplo:
        // Instanciar un proyectil, hacer daño al jugador, etc.
        yield return new WaitForSeconds(1.0f);
    }
}
