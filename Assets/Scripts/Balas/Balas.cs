using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    public int damageToPlayer;
    public GameObject player;
    public GameObject balasBool;
    private BalasPool balasPool;

    void Start()
    {
        // Buscar al jugador en el Hierachy
        player = GameObject.FindGameObjectWithTag("Player");
        balasBool = GameObject.FindGameObjectWithTag("pool");
        balasPool = balasBool.GetComponent<BalasPool>();
    }

    void Update()
    {
        if (player != null)
        {
            // Obtener el componente Player del jugador si existe
            Player playerDamage = player.GetComponent<Player>();

            if (playerDamage != null)
            {
                // Asignar el daño del jugador a la bala
                damageToPlayer = playerDamage.damage;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("muro"))
        {
            balasPool.ReturnBulletToPool(gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            balasPool.ReturnBulletToPool(gameObject);
        }
    }
}

