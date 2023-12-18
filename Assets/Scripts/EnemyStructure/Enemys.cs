using System.Collections;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public PuntuacionesSO puntuacionesSO;
    public int vida;
    public int maxVida;
    public int damage;
    public int velocidad;
    protected Transform jugadorPos;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        vida = maxVida;
        jugadorPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balas"))
        {
            Balas damage = other.GetComponent<Balas>();
            vida -= damage.damageToPlayer;
            if (vida <= 0)
            {
                Debug.Log("anim muerte");
                anim.SetBool("IsDead", true);
                velocidad = 0;
                StartCoroutine(Destruir(2f)); 
            }
        }
    }

    private IEnumerator Destruir(float retardo)
    {
        puntuacionesSO.enemigosMatados++; 
        yield return new WaitForSeconds(retardo); 
        Destroy(gameObject);
    }
}
