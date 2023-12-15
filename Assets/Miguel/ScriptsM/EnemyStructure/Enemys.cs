using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    protected int vida;
    protected int maxVida;
    protected int damage;
    protected int velocidad;
    public EnemyData EnemyData; // Referencia al Scriptable Object de estadísticas de enemigo
    protected Transform jugadorPos;

    private void Start()
    {
        jugadorPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (EnemyData != null)
        {
            vida = EnemyData.vida;
            maxVida = EnemyData.maxVida;
            damage = EnemyData.damage;
            velocidad = EnemyData.velocidad;
            // Asigna otras estadísticas según sea necesario para el enemigo
        }
    }
}
