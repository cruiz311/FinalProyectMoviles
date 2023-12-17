using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotFollowAtPlayer : Enemys
{
    private Vector3 posicionObjetivo;

    public bool Target;

    private bool Fire = false;

    private void Awake()
    {
        MoverAleatoriamente();
    }
    private void Update()
    {

        if (Fire == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
            transform.LookAt(posicionObjetivo);
            if (Vector3.Distance(transform.position, posicionObjetivo) < 0.1f)
            {
                if (Target == true)
                {
                    StartCoroutine(TargetAttack());
                }
                else
                {
                    StartCoroutine(RandomAttack());
                }
            }
        }
        else
        {
            MoverAleatoriamente();
        }
        
    }
    public void MoverAleatoriamente()
    {
        float randomX = Random.Range(-3.5f, 3.5f);
        float randomZ = Random.Range(-20, 20);

        posicionObjetivo = new Vector3(randomX, 0, randomZ);
    }


    IEnumerator TargetAttack()
    {
        Debug.Log("1");
        if (jugadorPos != null)
        {
            Debug.Log("2");
            transform.LookAt(jugadorPos);
            Debug.Log("Ataque al jugador");
            Fire = true;
        }
        yield return new WaitForSeconds(1.0f);

        Fire = false;
    }

    IEnumerator RandomAttack()
    {

        Fire = true;
        Debug.Log("Ataque Random");
        yield return new WaitForSeconds(1.0f);

        Fire = false;
    }
}
