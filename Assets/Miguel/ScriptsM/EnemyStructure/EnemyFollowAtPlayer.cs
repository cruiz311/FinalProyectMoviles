using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAtPlayer : Enemys
{
    // Update is called once per frame
    void Update()
    {
        if (jugadorPos != null)
        {
            transform.LookAt(jugadorPos);
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }

    IEnumerator AttackMele()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
