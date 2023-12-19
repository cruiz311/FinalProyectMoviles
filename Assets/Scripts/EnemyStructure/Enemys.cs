using System.Collections;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public PuntuacionesSO puntuacionesSO;
    public int vida;
    public int maxVida;
    public int damage;
    public int velocidad;
    public bool muerto = false;
    protected Transform jugadorPos;
    public GameObject puntuacion;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        vida = maxVida;
        puntuacion = GameObject.FindGameObjectWithTag("puntuacion");
        puntuacionesSO = puntuacion.GetComponent<puntuacionController>().puntuacionesSO;
        jugadorPos = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balas"))
        {
            Balas damage = other.GetComponent<Balas>();
            vida -= damage.damageToPlayer;
            if (vida <= 0 && muerto == false)
            {
                muerto = true;
                Debug.Log("anim muerte");
                anim.SetBool("IsDead", true);
                puntuacionesSO.enemigosMatados++;
                velocidad = 0;
                StartCoroutine(Destruir(2f)); 
            }
        }


        if (other.CompareTag("PlayerPrincipal"))
        {
            Debug.Log("aaaaaaaaaaaaaaaa");
            Player player = other.GetComponent<Player>();
            player.vida -= damage;
            StartCoroutine(Ataque());
        }
    }

    


    private IEnumerator Ataque()
    {
        yield return new WaitForSeconds(2f);
    }
    private IEnumerator Destruir(float retardo)
    {
        
        yield return new WaitForSeconds(retardo); 
        Destroy(gameObject);
    }
}
