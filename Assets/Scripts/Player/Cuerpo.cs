using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerpo : MonoBehaviour
{
    private BalasPool balasPool;
    private Player jug;
    public Enemys target;

    public GameObject brazo;

    [Header("Balas")]
    public GameObject bala;
    public bool isShooting = false;

    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject balasBool = GameObject.FindGameObjectWithTag("pool");
        jug = player.GetComponent<Player>();
        balasPool = balasBool.GetComponent<BalasPool>();
    }
    void Update()
    {
        target = jug.target;
        if (target != null)
        {
            LookThis(target.transform);
            if (!isShooting) // Verificar si no se está disparando actualmente
            {
                StartCoroutine(Shot());
            }
        }  
    }
    public void LookThis(Transform posicion)
    {
        if (posicion != null)
        {
            Vector3 direction = posicion.position - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
            }
        }
    }

    public IEnumerator Shot()
    {
        isShooting = true;

        while (target != null)
        {
            GameObject newBullet = balasPool.GetBulletFromPool();

            if (newBullet != null)
            {
                newBullet.transform.position = brazo.transform.position;
                newBullet.transform.rotation = Quaternion.identity;

                Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = transform.forward * 20f; // Dirección y velocidad de la bala
                }
            }

            yield return new WaitForSeconds(jug.velocidadAtaque);
        }

        isShooting = false;
    }
}
