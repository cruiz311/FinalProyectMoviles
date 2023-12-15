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
        jugadorPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
