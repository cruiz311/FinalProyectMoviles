using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public int vida;
    public int maxVida;
    public int damage;
    public int velocidad;
    protected Transform jugadorPos;

    private void Start()
    {
        vida = maxVida;
        jugadorPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Dentro del script del enemigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balas"))
        {
            Balas damage = other.GetComponent<Balas>();
            vida -= damage.damageToPlayer;
            if (vida <= 0)
            {
                // Lógica de muerte del enemigo
                // Por ejemplo, activar una animación de muerte, reproducir efectos de sonido, etc.
                Destroy(gameObject); // Destruir el enemigo si su vida llega a cero o menos
            }
        }
    }

}
